    namespace MySystem{
       namespace Foo{
           class Bar {...}
       }
    
       class Bar{...}
    }
    
    using MySystem;
    class MyClass{
        private Bar _myBar; //Which one is it MySystem.Foo.Bar or MySystem.Bar?     
    }
