    using System;
    
    public class MainClass {
        public static void Main() {
    
            Console.WriteLine("Hei");
    
            Asset a = new House();        
            Foo(a);    
            Foo((dynamic)a);  
    
            object x = 7;
            Foo((dynamic)x);
        }
    
        public static void Foo(House h) { Console.WriteLine("House"); }
        public static void Foo(Asset a) { Console.WriteLine("Asset"); }
        public static void Foo(int i) { Console.WriteLine("int"); }
    }
    
    
    public class Asset {
    }
    
    public class House : Asset {
    }
