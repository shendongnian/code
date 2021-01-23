    public class Person:INotifyPropertyChanged,IDataErrorInfo
    {
    
    ...
    
       string IDataErrorInfo.this[string propertyName]
       {
            get { return this.GetValidationError(propertyName); }
       }
    ...
       string GetValidationError(string propertyName)
       {
            if(propertyName == "PersonName")
                 //do the validation here returning the string error
       }
    }
