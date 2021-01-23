    public class RegisterViewModel
    {
        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "YouMustAcceptTermsAndConditions")]
        [Display(Name = "Agree to terms.")]
        public bool AgreeTerms { get; set; }
