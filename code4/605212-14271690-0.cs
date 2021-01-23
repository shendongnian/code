        if (!dict.ContainsKey(key)) 
           throw New InvalidArgumentException();
   
        StrategyBase EnumImp = null;
        var instance = dict[key].MakeGenericType(typeOf(type)).GetProperty("Instance",  BindingFlags.Static | BindingFlags.Public ));   //dict is Dictionary<string, Type>
        
        
