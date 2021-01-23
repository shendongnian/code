    public class ClassFactory
    {
        static Dictionary<string, object> _Instances;
        public static object Get(string type)
        {
            lock (_Instances)
            {
                object inst;
                if (_Instances.TryGetValue(type, out inst)) return inst;
                inst = Activator.CreateInstance(Type.GetType(type));
                _Instances.Add(type, inst);
                return inst;
            }
        }
    }
