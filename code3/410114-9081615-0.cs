    namespace MyNamespace 
    { 
        public class Foo 
        { 
            public static bool Invert = false; 
            public int A {get; set;} 
            .... 
        } 
     
        public class FooFactory 
        { 
            public Foo Foo(int A)  
            { 
               if(MyNamespace.Foo.Invert)
                  return new MyNamespace.Foo(-A); 
               else 
                  return new MyNamespace.Foo(A); 
            } 
        } 
    } 
