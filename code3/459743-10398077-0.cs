    public class MyViewModel
    {
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Is Phone Number Required")]
        [RegularExpression(@"^(?:[0-9]+(?:-[0-9])?)*$")]
        public string PhoneNumber { get; set; }
    }
