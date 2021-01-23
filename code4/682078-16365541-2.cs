    Thing GetThing(String str)
    {
         // Make a static method that tests the string.
         if (Thing.IsLegit(str)) 
             return new Thing(str);
         return null;
    }
    void FindingObjectType(String str)
    {
        Thing thing = GetThing();
        if(thing != null)
             //process
    }
