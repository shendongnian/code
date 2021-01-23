    public struct Item
    {
       privateItem Value;
       public Type1 Data1 {get {return Value.Data1; }}
       public Type1 Data2 {get {return Value.Data2; }}
       Item(privateItem src)
       {
         Value = src;
       }
     }
