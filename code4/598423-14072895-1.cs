    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApplication4
    {
        class Member
        {
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string Line3 { get; set; }
            public string Name { get; set; }
    
        }
    
        static class Program
        {
            private static readonly List<object> MyRefObjHolder = new List<object>();
    
            private static void Main()
            {
    
                Member m = new Member {Line1 = "line1", Line2 = "line2", Line3 = "line3", Name = "m"};
    
                Member n = new Member {Line1 = "line1", Line2 = "line2", Line3 = "line3", Name = "n"};
    
                MyRefObjHolder.Add(m);
                MyRefObjHolder.Add(n);
    
                string tmp1 = GetCompleteNameWithProperty("m.Line1");
                string tmp2 = GetCompleteNameWithProperty("n.Line1");
                Console.WriteLine(tmp1); // prints : Member.Line1
                Console.WriteLine(tmp2); // prints : Member.Line2
                Console.Read();
    
            }
    
            public static string GetCompleteNameWithProperty(string objref)
            {
                
                string[] obj = objref.Split('.');
    
                if (obj.Length < 2)
                {
                    return null;
                }
    
                string className = obj[obj.Length - 2];
                string propName = obj[obj.Length - 1];
    
                string typeName = null;
                foreach (object o in MyRefObjHolder)
                {
                    Type type = o.GetType();
                    object name = type.GetProperty("Name").GetValue(o, null);
                    if (name != null && name is string && (string) name == className)
                    {
                        typeName = type.Name;
                    }
    
                }
    
                //linq based solution, replce the foreach loop with linq one :P
                //string typeName = (from o in myRefObjHolder select o.GetType() into type where type.GetProperty(propName) != null select type.Name).FirstOrDefault();
    
    
                return typeName != null ? string.Format("{0}.{1}", typeName, propName) : null;
            }
        }
    
    }
    
