    public class ProxyType : MarshalByRefObject
    {
        public void DoSomeStuff(string assemblyPath)
        {
            var someStuffAssembly = Assembly.LoadFrom(assemblyPath);
            //Do whatever you need with the loaded assembly, e.g.:
            var someStuffType = assembly.GetExportedTypes()
                .First(t => t.Name == "SomeStuffType");
            var someStuffObject = Activator.CreateInstance(someStuffType);
            someStuffType.GetMethod("SomeStuffMethod").Invoke(someStuffObject, null);
        }
    }
