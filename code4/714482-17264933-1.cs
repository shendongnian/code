    public object ExecuteCode(string code, string namespacename, string classname, string functionname, bool isstatic, params object[] args)
    {
        var asm = BuildAssembly(code);
        object instance = null;
        Type type;
        if(isstatic)
        {
            type = asm.GetType(namespacename + "." + classname);
        }
        else
        {
            instance = asm.CreateInstance(namespacename + "." + classname);
            type = instance.GetType();
        }
        return type.GetMethod(functionname).Invoke(instance, args);
    }
