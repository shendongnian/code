    INTEROPXLib.IDummy d = new INTEROPXLib.DummyClass();
    object array = new object[3];
    
    var t = typeof(INTEROPXLib.IDummy);
    object[] args = new Object[1];
    args[0] = array;
    ParameterModifier[] pms = new ParameterModifier[1];
    ParameterModifier pm = new ParameterModifier(1);
    pm[0] = true; // pass the 1st argument by reference
    pms[0] = pm; // add pm to the array of modifiers 
    var ret = t.InvokeMember("Fn", System.Reflection.BindingFlags.InvokeMethod, null, d, args, pms, null, null);
    Console.Out.WriteLine("Result = " + ret);
