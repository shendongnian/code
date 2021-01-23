    class MyType
    {
        public int prop1 { get; }
        public string prop2 { get; }
        public int[] prop3 { get; }
        public int prop4 { get; }
        public string prop5 { get; }
        public string prop6 { get; }
    
        public List<string> GetAllPropertyValues()
        {
            List<string> values = new List<string>();
            foreach (var pi in typeof(MyType).GetProperties())
            {
                values.Add(pi.GetValue(this, null).ToString());
            }
    
            return values;
        }
    }
