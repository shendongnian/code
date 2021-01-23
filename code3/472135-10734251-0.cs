    public class BaseClass
    {
        private static Dictionary<Type, object> ClassInstVarsDict = new Dictionary<Type, object>();
    
        public object ClassInstVar
        {
            get
            {
                object result;
                if (ClassInstVarsDict.TryGetValue(this.GetType(), out result))
                    return result;
                else
                    return null;
            }
            set
            {
                ClassInstVarsDict[this.GetType()] = value;
            }
        }
    }
    
    public class DerivedClass1 : BaseClass
    {
    }
    
    public class DerivedClass2 : BaseClass
    {
    }
