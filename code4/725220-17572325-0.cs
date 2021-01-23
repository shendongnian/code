    public class RegistrationIndexViewModel
    {
        public int dsRegistrationID { get; set; }
        [Display(Name = "Expression Of Interest ID")]
        public int dsExpressionOfInterestID { get; set; }
        [Display(Name = "SLA Received")]
        public bool SLAReceived { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Received")]
        public DateTime? SLAReceivedDate { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
    }
