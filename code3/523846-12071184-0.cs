    public class Person
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-mm-dd}")]  
        public DateTime DateOfBirth { get; set; }
    }
