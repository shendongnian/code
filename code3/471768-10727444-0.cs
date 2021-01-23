    internal class SettingsHolder
    {
    
        private Class1 originalProp;
        public Class1 OriginalProp
        {
            get
            {
                return originalProp;
            }
            set
            {
                originalProp = value;
                IsOriginalPropADefault = false;
            }
        }
    
        public bool IsOriginalPropADefault { get; private set; }
    
    }
