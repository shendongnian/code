    public static void DumpMethod(Delegate method)
    {
        var mb = method.Method.GetMethodBody();
        var il = mb.GetILAsByteArray();
        // note: you could probably use these as well to 
        // infer "hey, there's something in here"
        var exHandlers = mb.ExceptionHandlingClauses;
        var locals = mb.LocalVariables;
        var opCodes = typeof(System.Reflection.Emit.OpCodes)
            .GetFields()
            .Select(fi => (System.Reflection.Emit.OpCode)fi.GetValue(null));
        var mappedIL = il.Select(op => opCodes.FirstOrDefault(opCode => opCode.Value == op));
        foreach(var mappedOp in mappedIL)
        {
            Console.WriteLine("{0}", mappedOp.Name);
        }
    }
