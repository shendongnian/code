    var typeName = "Namespace.ClassName, Namespace";
    while (true)
    {
       var typeFound = Type.GetType(typeName);
       if (typeName == null)
       {
           Assembly assembly = Assembly.LoadFrom("abc.dll");
       }
       //monitor: AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize
       //memory will not grow after first call
    }
