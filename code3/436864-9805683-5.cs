    public Person(Int16 id, string name, List<Toy> toys)
    { 
        id = ID; 
        Name = name; 
        foreach(Toy item in toys) {
            item.Owner = this;
        }
        Toys = toys; 
    } 
