    public class RemoteLoader : MarshalByRefObject
    { 
        public void Load(string assemblyName, string typeName)
        {
            object instance = Activator.CreateInstance(assemblyName, typeName);
            //Do something with instance, or return shared interface of it.
        }
    }
