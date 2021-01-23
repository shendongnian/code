    class YourClass // or extract an interface
    {
        public string RowKey { get; set; }
    }
    
    class YourGeneric<T> where T : YourClass
    {
        // now T is strongly-typed class containing the property requested
    }
