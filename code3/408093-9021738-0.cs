    public class SomeObject : IDataErrorInfo
    {
        public string SomeString { get; set; }
        public Int32? SomeNumber { get; set; }
    
        #region IDataErrorInfo Members
    
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    
        public string this[string columnName]
        {
            get
            {
                if (columnName == "SomeString")
                {
                    int i;
                    if (int.TryParse(SomeString, i))
                    {
                        SomeNumber = i;
                    }
                    else
                    {
                        SomeNumber = null;
                        return "Value is not a valid number";
                    }
                }
                return null;
            }
        }
    
        #endregion
    }
