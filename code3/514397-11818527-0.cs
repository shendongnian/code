        class Foo
        {
          string Name
        }
        
        struct Bar
        {
          string Name
        }
    
        Foo f = new Foo()
        Foo g = f;
        f.Name = "Larry";
        //Since g and f point to the same reference variable both have a name of "Larry"
        //changes to one, change all instances that point to the same value
        Bar b = new Bar();
        Bar c = b;
        b.Name = "Paul"
        //Since Bar is a value type, when we set the name of b, c is not altered because 
        //b and c do not refer to the same value they are independent value types 
        //and can vary separately.
