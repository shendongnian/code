    [RequiredIf(DependentName = "Country", DependentValue="USA")]
    public string PostalCodeUSA { get; set; }
    
    [RequiredIf(DependentName = "Country", DependentValue="Canada")]
    public string PostalCodeCanada { get; set; }
