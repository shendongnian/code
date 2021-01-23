    using System;
    using System.Collections.Generic;
    
    class myClass{
    
        public string Name { get; set; }
        public myClass(){
        }
    }
    
    class MainClass
    {
    
        public static void Main() 
        {
            string[] array = new string[] { "one", "two", "three" };
            IDictionary<string,myClass> col= new Dictionary<string,myClass>();
            foreach (string name in array)
            {
                  col[name] = new myClass { Name = "hahah " + name  + "!"};
            }
    
            foreach(var x in col.Values)
            {
                  Console.WriteLine(x.Name);
            }
            Console.WriteLine("Test");
            Console.WriteLine(col["two"].Name);
        }
    }
