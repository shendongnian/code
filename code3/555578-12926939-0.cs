    public class DateRangeAttribute : ValidationAttribute, IClientValidatable {
      public DateTime MinimumDate = new DateTime(1901, 1, 1);
      public DateTime MaximumDate = new DateTime(2099, 12, 31);
      private Type _resourceType;
    
       public DateRangeAttribute(string minDate, string maxDate, string errorMessage, Type resourceType) {
         _resourceType = resourceType;
         var minDateProp = _resourceType.GetProperty(minDate, 
                                 BindingFlags.Static | BindingFlags.Public);
         var minDateValue = (string) minDateProp.GetValue((object) null, (object[]) null));
         MinimumDate = DateTime.Parse(minDateValue);
         
         // similarly get the value for MaxDate
         ErrorMessage = string.Format(errorMessage, 
                MinimumDate.ToString("MM/dd/yyyy"), MaximumDate.ToString("MM/dd/yyyy"));         
       }
    }
