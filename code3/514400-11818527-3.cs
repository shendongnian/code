    class Foo
    {
      public string Name;
    }
    
    struct Bar
    {
      public string Name;
    }
    Foo f = new Foo();
    Foo g = f;
    f.Name = "Larry";
    //Since g and f point to the same object both have a name of "Larry"
    //changes to one, change all instances that point (refer) to the same object (memory location)
    Bar b = new Bar();
    Bar c = b;
    b.Name = "Paul";
    //Since Bar is a value type, when we set the name of b, c is not altered because 
    //b and c do not refer to the same object, they are independent variables
    //each allocated their own memory
    //and can vary separately after the initial assignment. 
