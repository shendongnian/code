    public List<int> MyAgeList {get; set;}
    // Constructor
    public CarViewModel()
    {
        MyAgeList = new AgesViewModel().GetAges();
    }
