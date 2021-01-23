    public class EmployeeViewModel {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Error")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Error")]
        public string LastName { get; set; }
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
