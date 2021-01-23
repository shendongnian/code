     [DisplayName("My Custom Field")]
     [MyCustomRangeAttribute(/* blah */)] //<-- the new range attribute you write
     public string MyCustomFieldString
     {
       get; set;
     }
     public int? MyCustomField
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
       set
       {
          MyCustomFieldString = value != null ? value.Value.ToString() : null;
       }
     }
