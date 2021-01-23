    void TortureMutableBoxedValueType()
    {
      object o1 = new IntWrapper(5);
      object o2 = o1;
      Console.WriteLine(((IValue)o1).Value); // outputs original 5
      ((IValue)o2).Value = 8; 
      Console.WriteLine(((IValue)o1).Value); // outputs new 8
    }
    interface IValue 
    {
      int Value {get;set;}
    }
    
    // Don't use mutable value types - this is just sample.
    public struct IntWrapper : IValue 
    {
      int v;
      public int Value { get { return v;} set {v = value;}}
      public IntWrapper(int value) { v = value; }
    }
