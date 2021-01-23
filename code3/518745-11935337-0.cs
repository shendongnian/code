    class Person {
       string Name { get; set; }
       string Address { get; set; }
       int age { get; set; }
    }
    
    public void UpdateName(Person p)
    {
       if (p == null) 
       {
          return;
       }
       p.Name = "Tom";
    }
    
    public void UpdateName(ref Person p)
    {
       if (p == null)
       {
          p = new Person();
       }
       p.Name = "Tom";
    }
