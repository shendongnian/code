    private FieldInfo[] GetConstants(System.Type type)
    {
        ArrayList constants = new ArrayList();
    
        FieldInfo[] fieldInfos = type.GetFields(
            // Gets all public and static fields
    
            BindingFlags.Public | BindingFlags.Static | 
            // This tells it to get the fields from all base types as well
    
            BindingFlags.FlattenHierarchy);
        
        // Go through the list and only pick out the constants
        foreach(FieldInfo fi in fieldInfos)
            // IsLiteral determines if its value is written at 
            //   compile time and not changeable
            // IsInitOnly determines if the field can be set 
            //   in the body of the constructor
            // for C# a field which is readonly keyword would have both true 
            //   but a const field would have only IsLiteral equal to true
            if(fi.IsLiteral && !fi.IsInitOnly)
                constants.Add(fi);           
    
        // Return an array of FieldInfos
        return (FieldInfo[])constants.ToArray(typeof(FieldInfo));
    }
    
