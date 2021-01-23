    public void Function1<TType1, TType2>() 
        where TType1 : new() 
        where TType2 : new()
    {
        if(typeof(TType1) != typeof(Namespace1.MyType1) || 
           typeof(TType1) != typeof(Namespace2.MyType1) || 
           typeof(TType2) != typeof(Namespace1.MyType2) || 
           typeof(TType2) != typeof(Namespace2.MyType2))
            throw new ArgumentException(...); 
    
        // .NET 4:
        dynamic type1 = new TType1();
        dynamic type2 = new TType2();
        // Pre .NET 4:
        // var type1 = new TType1();
        // var type2 = new TType2();
    
        // .NET 4:
        type1.InnerType = type2;
        // Pre .NET 4:
        // type1.GetType().GetProperty("InnerType").SetValue(type1, type2);
    
        // .NET 4:
        type1.PerformMethod1();
        // Pre .NET 4:
        // type1.GetType().GetMethod("PerformMethod1").Invoke(type1, new object[0]);
    }
