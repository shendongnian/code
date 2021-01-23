    [AttributeUsage(AttributeTargets.Property)]
    public class SessionAttribute : Attribute
    {
        public string Key { get; set; }
    }
    public class SampleClass : SessionObject
    {
        [Session(Key = "SS_PROP")]
        public int SampleProperty
        {
            get { return get<int>(); }
            set { set(value); }
        }
    }
    public abstract class SessionObject
    {
        Dictionary<string, object> Session = new Dictionary<string, object>();
 
        protected void set(object value)
        {
            StackFrame caller = new StackFrame(1);
            MethodBase method = caller.GetMethod();
            string propName = method.Name.Substring(4);
            Type type = method.ReflectedType;
            PropertyInfo pi = type.GetProperty(propName);
            object[] attributes = pi.GetCustomAttributes(typeof(SessionAttribute), true);
            if (attributes != null && attributes.Length == 1)
            {
                SessionAttribute ssAttr = attributes[0] as SessionAttribute;
                Session[ssAttr.Key] = value;
            }
        }
        protected T get<T>()
        {
            StackFrame caller = new StackFrame(1);
            MethodBase method = caller.GetMethod();
            string propName = method.Name.Substring(4);
            Type type = method.ReflectedType;
            PropertyInfo pi = type.GetProperty(propName);
            object[] attributes = pi.GetCustomAttributes(typeof(SessionAttribute), true);
            if (attributes != null && attributes.Length == 1)
            {
                SessionAttribute ssAttr = attributes[0] as SessionAttribute;
                if (Session.ContainsKey(ssAttr.Key))
                {
                    return (T)Session[ssAttr.Key];
                }
            }
            return default(T);
        }
    }
