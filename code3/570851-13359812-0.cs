    public class YourViewModel : BaseViewModel
    {
        [Required]
        [StringLenghtWarning(MaximumLength = 5, ErrorMessage = "Your Warning Message")]
        public string YourProperty { get; set; }
    }
