    public class ViewModel : IDataErrorInfo
    {
        public string this[string columnName]
        {
            // Never gets called!
            get
            { 
                if (columnName == "Value")
                    return GetValidationMessageForValueField();
                return null;
            }
        }
    }
