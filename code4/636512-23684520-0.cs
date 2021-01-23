    public class MyObject : INotifyPropertyChanged, IDataErrorInfo
    {
        ...
        public SecureString SecurePassword
        {
            get
            { ... }
            set
            {
                ...
                OnPropertyChanged("SecurePassword");
            }
        }
        
        ...
        
        string IDataErrorInfo.Error { get { return Validate(null); } }
        string IDataErrorInfo.this[string columnName] { get { return Validate(columnName); } }
        
        private string Validate(string memberName)
        {
            string error = null;
            ...
            if (memberName == "SecurePassword" || memberName == null)
            {
                // this is where I code my custom business rule
                if (SecurePassword == null || SecurePassword.Length == 0)
                {
                    error = "Password must be specified.";
                }
            }
            ...
            return error;
        }
    
    }
    
