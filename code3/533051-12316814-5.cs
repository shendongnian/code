    B b = new B {
        Name = "name"
    };
    
    AB ab = new AB {
    
        A = existingA,
        B = b,
        arbitraryProp = "my heart is a fist of blood" 
    
    }
    
    _myContext.Attach(existingA);
    _myContext.Add(b);
    _myContext.Add(ab);
    _myContext.SaveChanges();
