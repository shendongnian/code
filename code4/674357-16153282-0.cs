    public string Name { 
        get; 
    #if WriteSupport
        private set;
    #endif
    } 
    public int Age { 
        get; 
    #if WriteSupport
        private set;
    #endif
    }
    public Person(string Name, int Age)
    {
       this.Name = Name;
       this.Age = Age;
    }
