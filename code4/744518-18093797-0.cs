    namespace Foo
    {
        abstract class ExampleClass
        {
             //Only implement the class here
        }
    }
    namespace Engine
    {
        class ExampleClass : Foo.ExampleClass
        {
             //Don't implement anything here (other than constructors to call base constructors)
        }
    }
    namespace Core
    {
        class ExampleClass : Foo.ExampleClass
        {
             //Don't implement anything here (other than constructors to call base constructors)
        }
    }
