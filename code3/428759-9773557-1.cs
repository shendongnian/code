    public class Person
    {
        [Required]
        [RegularExpression(@"Bob|Harry")]  
        public string FirstName { get; set; }
        [Required, RegularExpression(@"5|30|50")]  
        public int Age { get; set; }
    }
