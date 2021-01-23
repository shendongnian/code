    public enum ContactOptionType
    {
        [Display(Description = "ContactOption1", ResourceType = typeof(Globalization.Contact))]
        Demo = 1,
        
        [Display(Description = "ContactOption2", ResourceType = typeof(Globalization.Contact))]
        Callback = 2,
        
        [Display(Description = "ContactOption3", ResourceType = typeof(Globalization.Contact))]
        Quotation = 3,
        
        [Display(Description = "ContactOption4", ResourceType = typeof(Globalization.Contact))]
        Other = 4
    }
