    public class MyClass : IDataErrorInfo
    {
        ...
    
        #region IDataErrorInfo Members
    
        string IDataErrorInfo.Error
        {
            get { return null; }
        }
    
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "PhoneNumber")
                {
                    // Validate property and return a string if there is an error
                    return "Some error";
                }
    
                // If there's no error, null gets returned
                return null;
            }
        }
        #endregion
    }
