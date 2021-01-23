    const string AssemblyFilePath = @"path\to\assembly.dll";
    
    void Main()
    {
        var assembly = ModuleDefinition.ReadModule(AssemblyFilePath);
        var calls =
            (from type in assembly.Types
             from caller in type.Methods
             where caller != null && caller.Body != null
             from instruction in caller.Body.Instructions
             where instruction.OpCode == OpCodes.Call
             let callee = instruction.Operand as MethodReference
             select new { type, caller, callee }).Distinct();
    
        var directRecursiveCalls =
            from call in calls
            where call.callee == call.caller
            select call.caller;
    
        foreach (var method in directRecursiveCalls)
            Debug.WriteLine(method.DeclaringType.Namespace + "." + method.DeclaringType.Name + "." + method.Name + " calls itself");
    }
