    [ScriptableType]                       
    public class SMT_ScriptableManagedType
        {
        [ScriptableMember(EnableCreateableTypes = false)] // No access
         public string GetString1()
            { return "abcdefg"; }
    
         public string GetString2()            // Can be accessed.
            { return "123456"; }
    }
