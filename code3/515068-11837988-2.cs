    // Let's calculate an Area from a Radius
    double SomeRadius = 1.234;
    
    MyObj1 = new class1();
    double Area = MyObj1.Area(SomeRadius);
    
    double StoredRadius = MyObj1.Radius; // This will give you back the Radius stored by MyObj1, which is the same you passed to Area() function
    
    // Now let's calculate a Volume, using the Radius we indicated earlier and a Depth
    double SomeDepth = 4.567;
    MyObj2 = new class2();
    double Volume = MyObj2.Volume(SomeRadius, SomeDepth);
    
    double StoredDepth = MyObj2.Depth; // This will give you back the Depth stored by MyObj2, which is the same you passed to Volume() function
