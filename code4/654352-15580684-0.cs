    public class SimplePoint
    {
        [Required(ErrorMessage="MonitorKey is a required data field of SimplePoint.")]
        public Guid? MonitorKey { get; set; }
        [Required]
        public int? Data { get; set; }
    }
