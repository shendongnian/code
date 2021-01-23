    public class CustomerViewModel
    {
        [Required(ErrorMessage = "Next email date is required!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}"]
        public DateTime NextEmailDate { get; set; }
        ...
    }
    public class CustomerDetails
    {
        public CustomerViewModel Customer { get; set; }
    }
