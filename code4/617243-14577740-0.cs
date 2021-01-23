    using System;
    using System.Collections;
    using System.Reflection;
    namespace SO14577299
    {
        class Program
        {
            static void Main()
            {
                object result = new Hashtable();
                //Trying to get public fields via reflection:
                //there are no public fields on this class
                FieldInfo[] fields = result.GetType().GetFields();
                foreach (FieldInfo fieldInfo in fields)
                {
                    Console.WriteLine("Obj, Field: " + fieldInfo.Name);
                }
                Console.WriteLine("->1");
                Hashtable resultHash = result as Hashtable;
                //Trying to list all the keys
                //this is an empty collection, nothing there
                foreach (string keys in resultHash.Keys)
                {
                    Console.WriteLine("Obj, keys: " + keys);
                }
                Console.WriteLine("->2");
                
                resultHash = new Hashtable();
                resultHash["a"] = "1";
                resultHash["b"] = "2";
                //Trying to list all the keys
                //Now there are two: a and b
                foreach (string keys in resultHash.Keys)
                {
                    Console.WriteLine("Obj, keys: " + keys);
                }
                Console.WriteLine("->3");
            }
        }
    }
