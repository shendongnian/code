    interface IClass
    {
      string print(IClass item);
    }
    class MyClass : IClass
    {
      public string print(IClass item)
      { return item.ToString(); }
    }
