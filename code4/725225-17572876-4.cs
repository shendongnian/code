    public class dsRegistration
    {
        public int dsRegistrationID { get; set; }
        [Display(Name = "SLA Received")]
        public bool SLAReceived { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Received")]
        public DateTime? SLAReceivedDate { get; set; }
        //Indicate that a dsRegistration has an expresison of interest
        public dsExpressionOfInterest expressionOfInterest { get; set;}
    }
