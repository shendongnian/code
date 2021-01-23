    private static List<T> GetCodeLoadResults() where T : EntityCodeBase
    {
        Assembly assm = Assembly.Load(new System.Reflection.AssemblyName("RR"));
        Type tableType = //get table type from T
        MethodInfo mi = typeof(SpecificEntity).GetMethod("LoadAll");
    
        mi = mi.MakeGenericMethod(tableType);
        return (List<T>)mi.Invoke(null, null);
    }
