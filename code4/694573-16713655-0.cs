    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Due Date")]
    public Nullable<System.DateTime> Value{ get; set; }
