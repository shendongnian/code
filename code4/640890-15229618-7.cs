    INTEROPXLib.IDummy d = new INTEROPXLib.DummyClass();
    object data = new object[3]; // method argument, i.e. pParamArray value
    
    var t = typeof(INTEROPXLib.IDummy);
    object[] args = new object[1]; // array which will contain all method arguments
    args[0] = data; // data is the first argument, i.e. first element of args array
    ParameterModifier[] pms = new ParameterModifier[1];
    ParameterModifier pm = new ParameterModifier(1);
    pm[0] = true; // pass the 1st argument by reference
    pms[0] = pm;  // add pm to the array of modifiers 
    // invoke Fn by name via IDispatch interface
    var ret = t.InvokeMember("Fn", System.Reflection.BindingFlags.InvokeMethod, null, d, args, pms, null, null);
    Console.Out.WriteLine("Result = " + ret);
