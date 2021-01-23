    public void PassFuncs<Item>()
    {
      List<Func<Item>> funcs = new List<Func<Item>>();
      RecieveFuncs(funcs);  // C# automatically infers T = Item
    }
