    public class PersonHobbyViewModel {
    
        [Display(Name = "Person name:")]
        [Required(ErrorMessage = "Person name required.")]
        public string Name { get; set; }
    
        [Display(Name = "Hobby  description:")]
        [Required(ErrorMessage = "Hobby description required.")]
        public string Description { get; set; }
    }
