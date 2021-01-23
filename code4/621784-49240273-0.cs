    public class RegisterViewModel
    {
        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept terms and conditions.")]
        [Display(Name = "Agree to terms.")]
        public bool AgreeTerms { get; set; }
