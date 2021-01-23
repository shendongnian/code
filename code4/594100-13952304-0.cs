    public abstract class MyObject
    {
        public string name 
        { 
            get
            {
                return this.GetType().Name;
            }
        }
        public bool IsObject(string pattern);
        ...
    }
