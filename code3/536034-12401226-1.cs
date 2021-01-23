    enum Foo { Affect, AlarmState, CorrectValue, ... }
    
    public void InitializeArrays(int count)
    {
        Dictionary<Foo, string[]> response = new Dictionary<Foo, string[]>();
        // easy initialization of string arrays
        foreach (Foo foo in Enum.GetValues(typeof(Foo)))
        {
            response.Add(foo, new string[count]);
        }
        // use this to access the string arrays
        response[Foo.Affect][0] = "test";
        
        if (response[Foo.CorrectValue].Length > 0) { ... }
    }
    
