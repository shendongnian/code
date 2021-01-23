    // Create a new list and assign it to the public property of FooB...
    FooB.FooA_List = new List<FooA>();
    
    foreach (XElement elem in document.Descendants().Elements(nsUsr + "ExampleA"))
    {
        // Create a temporary variable (in the scope of this loop iteration) to store my new FooA class instance...
        FooA fA = new FooA() { 
            String_FA = elem.Element("A").Value, 
            String_FB = elem.Element("B").Value
        };
        
        // Because FooB.FooA_List is the list I want to add items to, I just access the public property directly.
        FooB.FooA_List.Add(fA);
    }
