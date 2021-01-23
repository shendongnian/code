    var parms = meth.GetParameters();
    int numArgs = parms.Length;
    if(numArgs == 0)
    {
        dType = typeof(Action);
    }    
    else 
    {
       var rawType = Type.GetType("System.Action`" + numArgs);
       dType = rawType.MakeGenericType(parms.Select(p => p.ParameterType).ToArray());
    }
