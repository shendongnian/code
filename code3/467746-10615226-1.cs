     public string MyCustomField
     {
       get; set;
     }
     public int? MyCustomFieldInt
     {
       get 
       { 
         if(string.IsNullOrWhiteSpace(MyCustomField))
           return null;
         int result;
         if(int.TryParse(MyCustomField, out result))
           return result;
         return null;
       }    
     }
