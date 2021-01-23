    public delegate object Func();
    
    public void PassFuncs<Item>()
    {
      List<Func<Item>> funcs = new List<Func<Item>>();
      RecieveFuncs(funcs.Select<Func<Item>, Func<object>>(f => () => (object)f())
                        .ToList());
    }
    
    public void RecieveFuncs(List<Func<object>> funcs)
    {
      //Do some stuff with funcs
    }
