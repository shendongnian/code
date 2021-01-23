    string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    //Usage
    Foo f = new Foo();
    f.Name = "John";
    string name = f.Name;
