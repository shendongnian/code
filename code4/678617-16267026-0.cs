    public class PersonViewModel
    {
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
    }
    public class PersonWithEmailViewModel : PersonViewModel
    {
        [Required]
        public String Email { get; set; }
    }
