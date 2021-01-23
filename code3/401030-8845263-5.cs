        public class SomeModel
        {
           [Display(Name = "Date of birth")]
           [MyDate(ErrorMessage ="Invalid date")]
           public DateTime DateOfBirth { get; set; }
        } 
