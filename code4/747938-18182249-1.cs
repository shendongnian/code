    Type tbase = typeof(Base);
    FieldInfo fi = tbase.GetField("<Name>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
    
    Base b = new Base {Name = "Test"};
      
    string baseValue = fi.GetValue(b).ToString();
    Console.WriteLine(baseValue); //gives "Test";
      
    Derived d = new Derived {Name = "Test" };
      
    string derivedValue = fi.GetValue(d).ToString();
    Console.WriteLine(derivedValue); //gives "Test from derived";
