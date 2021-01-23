    [ForeignKey("PatientContact"), Column(Order = 0)]
    public int Person_ID{ get; set; }
    [ForeignKey("PatientContact"), Column(Order = 1)]
    public int Patient_ID{ get; set; }
    public virtual PatientContact PatientContact { get; set; }
