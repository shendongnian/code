    static class Parser
    {
    
       public static int? ParseInt(this NamedValueCollection params, string name)
       {
           var textVal = params[name];
           int result = 0;
           if (string.IsNullOrEmpty(textVal) || !int.TryParse(textVal, out result))
           {
               return null;
           }
           return result;
       }
      
       public static bool TryParseInt(this NamedValueCollection params, string name, out int result)
       {
           result = 0;
           var textVal = params[name];
           if (string.IsNullOrEmpty(textVal))
             return false;
           return int.TryParse(textVal, out result);
       }
     
    ...
    
    }
