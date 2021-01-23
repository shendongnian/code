    public class Instance
    {
        public Type StaticObject { get; private set; }
        public Instance(Type staticType)
        {
            StaticObject = staticType;
        }
        public object Call(string name, params object[] parameters)
        {
            MethodInfo method = StaticObject.GetMethod(name);
            return method.Invoke(StaticObject, parameters);
        }
        public object Call(string name)
        {
            return Call(name, null);
        }
    }
