    // obtain our managed ABC from the workflow context
    ABCManaged abc = context.GetValue(this.InputABC);
    object[] parameters =  new object[2]; // method argument, i.e. parmArray value
    parameters[0] = new double();
    parameters[1] = abc;
    DEFManaged d = new DEFManaged(); // managed wrapper for our COM object
    var t = typeof(DEFManaged);
    object[] args = new object[1]; // array which will contain all method arguments
    args[0] = data; // data is the first argument, i.e. first element of args array
    ParameterModifier[] pms = new ParameterModifier[1];
    ParameterModifier pm = new ParameterModifier(1);
    pm[0] = true; // pass the 1st argument by reference
    pms[0] = pm;  // add pm to the array of modifiers 
    // invoke CallFunction by name via IDispatch interface
    var ret = t.InvokeMember("CallFunction", System.Reflection.BindingFlags.InvokeMethod, null, d, args, pms, null, null);
    Console.Out.WriteLine("Result = " + ret);
