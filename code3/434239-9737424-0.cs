    public SampleClass(string _name, byte _age, string _street, int _number)
    {
        this.Person = new Person();
        Person p = this.Person;
        p.Name = _name;
        p.Age = _age;
        this.Adress = new Adress();
        Adress a = this.Adress;
        a.Street = _street;
        a.Number = _number;
    }
    [Serializable]
    public Person Person { get; set; }
    [Serializable]
    public Adress Adress { get; set; }
