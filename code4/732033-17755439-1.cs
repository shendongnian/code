    [Table("CustomerAppointments")]
    public partial class CustomerAppointment
    {
    
        [Key,Column(Order=0)]
        public int? CustomerId { get; set; }
    
        [Key,Column(Order=1)]
        public int? VehicleId { get; set; }
    
        public DateTime? AppointmentDate { get; set; }
    
        public DateTime? AppointmentTime { get; set; }
    
        public string AvailableDays { get; set; }
    
        //other fields
    
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
    }
