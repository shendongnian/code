    public readonly string _name;
    public string Name { get { return _name; } } 
    private readonly int _age;
    public int Age { get { return _age; } }
    
    public Person(string Name, int Age)
    {
       this._name = Name;
       this._age = Age;
    }
