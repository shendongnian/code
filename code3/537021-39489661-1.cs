    var u = (from a in AppDomain.CurrentDomain.GetAssemblies()
             let t = a.GetType("System.Lazy`2")
             where t != null
             select t).FirstOrDefault();
    (u?.AssemblyQualifiedName).Dump();
    u = Type.GetType("System.Lazy`2, System.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
    (u?.AssemblyQualifiedName).Dump();
