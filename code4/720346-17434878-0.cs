    public class ViewModel : IDataErrorInfo
    {
        public string Error
        {
            get { return null; }
        }
    
        public string this[string propertyName]
        {
            get
            {
                if (propertyName == "Age")
                {
                    if (Age < 18)
                    {
                        return "Age must be at least 18.";
                    }
                }
    
                return null;
            }
        }
    }
