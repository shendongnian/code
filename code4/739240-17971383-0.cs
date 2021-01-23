    public class MarkupState
    {
        public int PayrollMarkupId { get; set; }
        public string State { get; set; }
        [UIHint("StatesEditor")]
        public int StateId { get; set; }
        public decimal? MaintenancePercentage { get; set; }
        public decimal? OfficePercentage { get; set; }
    }
