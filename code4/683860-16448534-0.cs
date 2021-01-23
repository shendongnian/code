    [DataContract]
    public class MyObject
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Nullable<int> AuditProgramId { get; set; }
        [DataMember]
        [Required]
        public string Title { get; set; }
        [Required, DataType(DataType.Date)]
        [DataMember(IsRequired = true)]
        public System.DateTime StartDate { get; set; }
        [Required, DataType(DataType.Date)]
        [DataMember(IsRequired = true)]
        public System.DateTime EndDate { get; set; }
    }
