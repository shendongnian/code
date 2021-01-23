    //here you are declaring a private field of class
    private List<FixedTickProvider> minorTickProviders;
    //and only exposing get to rest of the code
    public List<FixedTickProvider> MinorTickProviders { get { return minorTickProviders; } }
    
    //here you are declaring a public property which can only be set by the class which is declaring it
    public List<FixedTickProvider> MinorTickProviders { get; private set; }
