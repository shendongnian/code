    class DataElement
    {
      public string Name { get; set; }
      public bool Persistent { get; set; }
    
      public DataElement(/* ctor params */)
      {
      }
    }
    
    class DataElement<T> : DataElement
    {
      public DataElement(string name, T defaultValue /* other ctor params */)
        : base(/* base ctor params */)
      {
      }
    }
    
    class IntElement : DataElement<int> {}
    class DoubleElement : DataElement<double> {}
