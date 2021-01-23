    class MyDictionary : Dictionary<string, string> 
    {
       public MyDictionary (){ }
       protected MyDictionary (SerializationInfo info, 
                               StreamingContext ctx) : base(info, ctx) { }
    }
