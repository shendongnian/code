    // In SQL
    CREATE FUNCTION dbo.ToFormattedString ...
    // In C#
    public static class EntityFunctions 
    { 
        [EdmFunction("dbo", "ToFormattedString")] 
        public static string ToFormattedString(this string input) 
        { 
            throw new NotSupportedException("Direct calls not supported");  
        } 
    }
    var results = db.Jobs.Where(j => j.Country.ToFormattedString() == urlFormattedString);
