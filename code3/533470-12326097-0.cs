    class C
    {
        private Lazy<int> p = new Lazy<int>(() => Service.GetP());
    
        private int P
        {
            get
            {
                return p.Value;
            }
        }
    }
