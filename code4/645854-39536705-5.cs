    [Key]
    [Column("DepartmentCode")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [StringLength(8)]
    [Display(Name = "Department Code")]
    public string DepartmentCode { get; set; }
