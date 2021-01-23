    public partial class MyClass : IDataErrorInfo
    {
        partial void ValidateMyProperty(ref string error);
        
        public string this[string propertyName]
        {
            get
            {
                string error = String.Empty;
                if (propertyName == "MyProperty")
                    ValidateMyProperty(ref error);
                
                return error;
            }
        }
    
        public string Error { get { return String.Empty; } }
    
        public int MyProperty { get; set; }
    }
