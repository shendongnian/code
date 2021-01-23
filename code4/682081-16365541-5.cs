    Thing GetThing(String str)
    {
         Thing thing = new Thing(str);
         if(thing.Legit)
             return thing;
         return null;
    }
    void FindingObjectType(String str)
    {
        Thing thing = GetThing();
        if(thing != null)
             //process
    }
