    //syntax based on version 0.9.5.4 (http://nuget.org/packages/Mono.Cecil/0.9.5.4)
    using Mono.Cecil;  
    using Mono.Cecil.Cil;
    //...
    string assemblyPath = (@"path to your unit test assembly\MyTests.dll");
    AssemblyDefinition asm = AssemblyDefinition.ReadAssembly(assemblyPath);
    List<MethodDefinition> testsThatCallDummyMethods =
        (from mod in asm.Modules
            from t in mod.Types
            from meth in t.Methods
            where meth.Body != null
            from instr in meth.Body.Instructions
            let op = instr.Operand as MethodDefinition
            where
                instr.OpCode == OpCodes.Callvirt &&
                op != null &&
                op.DeclaringType.FullName ==
                "Lib.Dummy" //namespace qualified type name
                && op.Name ==
                "DoDummyThings1" //method names...
            select meth)
            .ToList();
