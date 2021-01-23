    public class YourViewModel : BaseViewModel
    {
        [Required]
        [StringLengthWarning(MaximumLength = 5, ErrorMessage = "Your Warning Message")]
        public string YourProperty { get; set; }
    }
