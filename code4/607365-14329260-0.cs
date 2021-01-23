    public enum CheckType
    {
        Nice,
        Pretty,
        // And so on...
    }
    public Boolean IsWhat(ExampleStruct struct, CheckType type)
    {
        switch (type)
        {
            case CheckType.Pretty: 
               return toVerify.IsPretty;
            
             // And so on...
        }    
    }
