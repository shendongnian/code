    public List<ContactNumber> ContactNumbers { get; set; }
    public Human(int id)
    {
        Id = id;
        ContactNumbers = new List<ContactNumber>();
    }
    public Human(int id, string address, string name) :this(id)
    {
        Address = address;
        Name = name;
        // no need to initialize the list here since you're
        // already calling the single parameter constructor
    }       
