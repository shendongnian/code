    Type t = Type.GetType(String.Format("OtherAssembly.{0}Factory", typeName));
    var myFactory = Activator.CreateInstance( t );
    
    MethodInfo m = t.GetMethods().Where(a => a.ReturnType.Name == typeName).FirstOrDefault();
    
    return m.Invoke(myFactory, new object[] { /* PARAMETERS */ });
