    [System.Runtime.Serialization.DataContract]
    public class MySingletonClass : System.Runtime.Serialization.IObjectReference
    {
        private MySingletonClass()
        {
        }
        
        private static MySingletonClass _Instance;
        public static MySingletonClass Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new MySingletonClass();
                return _Instance;
            }
        }
    
        object System.Runtime.Serialization.IObjectReference.GetRealObject(StreamingContext context)
        {
            MySingletonClass realObject = Instance;
            realObject.Merge(this);
            return realObject;
        }
        
        private void Merge(MySingletonClass otherInstance)
        {
            // do your merging here
        }
    }
