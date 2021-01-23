    namespace MySystem{
       namespace Foo{
           class Baz {...}
       }
    
       namespace Bar{
           class Baz {...}
       }
    }
    
    using MySystem;
    class MyClass{
        private readonly Baz _myBaz; //Which one is it Foo.Baz or Bar.Baz?     
    }
