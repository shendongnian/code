    class Person { public string Name { get; set; } }
    
    void Main()
    {
        var p = new Person { Name = "Homer" };
        // p.Name = "Homer"
        M2(p);
        // p != null
        // p.Name = "Bart"
    }
    
    void M2(Person p)
    {
        p.Name = "Bart";
        p = null;          // no effect 
    }
