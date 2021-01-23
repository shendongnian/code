    class Person { public string Name { get; set; } }
    void Main()
    {
        var p = new Person { Name = "Homer" };
        // p != null
        // p.Name = "Homer"
        M2(p);
        // p != null
        // p.Name = "Bart"
    }
    void M2(Person q)
    {
        q.Name = "Bart";   // q references same object as p
        q = null;          // no effect, q is a copy of p
    }
