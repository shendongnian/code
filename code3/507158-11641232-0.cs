    namespace MyNamespace
    {
        public class ClassA {
            int p1 = 1;
            string p2 = "abcdef"; 
            List<string> p3 = new List<string>() { "ghi","lmn" };
            ClassB p4 = new ClassB();
            ClassB p5 = null;
    
            public int PA1 { get { return p1; } }
            public string PA2 { get { return p2; } }
            public List<string> PA3 { get { return p3; } }
            public ClassB PA4 { get { return p4; } }
            public ClassB PA5 { get { return p5; } }
        }
    
        public class ClassB{
            private string p1 = "zeta";
            public string PB1 { get { return p1; } }
        }
    
        public class Program {
    
            public void Main()
            {
                ClassA o = new ClassA();
                Dictionary<string, string> result = GetPropertiesDeepRecursive(o, "[o]", new List<string>() { "MyNamespace" });
            }
    
            /// <summary>
            /// Returns a dictionary of propertyFullname-value pairs of the given object (and deep recursively for its public properties)
            /// note: it's object oriented (on purpose) and NOT type oriented! so it will just return values of not null object trees
            /// <param name="includedNamespaces">a list of full namespaces for whose types you want to deep search in the tree</param>
            /// </summary>        
            public Dictionary<string, string> GetPropertiesDeepRecursive(object o, string memberChain, List<string> includedNamespaces)
            {
    
                List<string> types_to_exclude_by_design = new List<string>() { "System.string", "System.String" };
    
                //the results bag
                Dictionary<string, string> r = new Dictionary<string, string>();
    
                //if o is null just return value = [null]
                if (o == null)
                {
                    r.Add(memberChain, "[null]");
                    return r;
                }
    
                //the current object argument type
                Type type = o.GetType();
    
                //reserve a special treatment for specific types by design (like string -that's a list of chars and you don't want to iterate on its items)
                if (types_to_exclude_by_design.Contains(type.FullName))
                {
                    r.Add(memberChain, o.ToString());
                    return r;
                }
    
                //if the type implements the IEnumerable interface...
                bool isEnumerable =
                    type
                    .GetInterfaces()
                    .Any(t => t == typeof(System.Collections.IEnumerable));
                if (isEnumerable)
                {
                    int i_item = 0;
                    //loop through the collection using the enumerator strategy and collect all items in the result bag
                    //note: if the collection is empty it will not return anything about its existence,
                    //      because the method is supposed to catch value items not the list itself                
                    foreach (object item in (System.Collections.IEnumerable)o)
                    {
                        string itemInnerMember = string.Format("{0}[{1}]", memberChain, i_item++);
                        r = r.Concat(GetPropertiesDeepRecursive(item, itemInnerMember, includedNamespaces)).ToDictionary(e => e.Key, e => e.Value);
                    }
                    return r;
                }
    
                //here you need a strategy to exclude types you don't want to inspect deeper like int,string and so on
                //in those cases the method will just return the value using the specific object.ToString() implementation
                //now we are using a condition to include some specific types on deeper inspection and exclude all the rest
                if (!includedNamespaces.Contains(type.Namespace))
                {
                    r.Add(memberChain, o.ToString());
                    return r;
                }
    
                //otherwise go deeper in the object tree...            
                //and foreach object public property collect each value
                PropertyInfo[] pList = type.GetProperties();
                foreach (PropertyInfo p in pList)
                {
                    object innerObject = p.GetValue(o, null);
                    string innerMember = string.Format("{0}.{1}", memberChain, p.Name);
                    r = r.Concat(GetPropertiesDeepRecursive(innerObject, innerMember, includedNamespaces)).ToDictionary(e => e.Key, e => e.Value);
                }
                return r;
            }
        }
    }
