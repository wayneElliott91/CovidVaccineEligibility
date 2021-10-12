using System;
using System.ComponentModel.DataAnnotations;

namespace CovidVaccineEligibility
{
    /*
     * Which Vaccine: Based on the details entered, use the table 						
     * below to determine which vaccine the person is most likely to get.
     * 
    Age     Gender      Vaccine
    >50     Male        AstraZeneca
    >50     Female      Pfizer
    >35     Male        AstraZeneca
    >35     Female      Pfizer
    >20     Male        Johnson & Johnson
    >20     Female      AstraZeneca
    <20     All         Johnson & Johnson
     */
    public enum SuitableVaccines
    {
        [Display(Name = "AstraZeneca")] AstraZeneca,
        [Display(Name = "Pfizer")] Pfizer,
        [Display(Name = "Johnson & Johnson")] JohnsonAndJohnson
    }

    public enum Gender
    {
        Male,
        Female,
        [Display(Name = "Don't want to declared")]
        DontWantToDeclare
    }

    //Class to present to the Internet
    public class VaccineEligibility
    {
        public const int ageMin = 12;
        public const int ageMax = 110;

        public string name { get; set; }
        public Gender gender { get; set; }

        [Range(ageMin, ageMax, ErrorMessage = "Invalid age - Vaccine Only Available from 12 to 110")]
        public int age { get; set; }


        // calculate which vaccine is most suitable
        public string vaccine
        {
            get
            {
                string Message = "";

                if(age > 50 && gender.Equals(Gender.Male) ) {
                    Message = SuitableVaccines.AstraZeneca + " is the most suitable vaccine for you.";
                }

                return "You are " + this.age + " and " + this.gender + ". " + Message;
            }
        }
    }
}
