    using System.ComponentModel.DataAnnotations;
    
    public class Person
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
