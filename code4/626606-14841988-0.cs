    Account.cs
    public Guid Id {get; set;}
    public string Name {get; set;}
    public bool IsActive {get; set;}
    public IEnumerable<AgreedToTerms> AgreedTerms { get; set; }
    
    Terms.cs
    public Guid Id {get; set;}
    public string Text {get; set;}
    public DateTime Created {get; set;}
    public IEnumerable<AgreedToTerms> AgreedUsers { get; set; }
    
    AgreedToTerms.cs
    public Account User { get; set; }
    public Terms Terms { get; set; }
    public DateTime DateOfAgreement {get; set;}
