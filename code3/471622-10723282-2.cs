    Type t = Type.GetType(String.Format("OtherAssembly.{0}Factory", typeName));
    
    MethodInfo m = t.GetMethods().Where(a => a.ReturnType.Name == typeName).FirstOrDefault();
    
    return m.Invoke(null, new object[] { /* PARAMETERS */ });
