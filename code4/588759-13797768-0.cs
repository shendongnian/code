    namespace MyProject.Whatever
    {
        internal interface IHidden
        {
            void Manipulate();
        }
    
        internal class MyClass : IHidden
        {
            private string privateMember = "World!";
    
            public void SayHello()
            {
                Console.WriteLine("Hello " + privateMember);
            }
    
            void IHidden.Manipulate()
            {
                privateMember = "Universe!";
            }
        }
    }
    
    namespace MyProject.Whatever.Manipulatable
    {
        static class MyClassExtension
        {
            public static void Manipulate(this MyClass instance)
            {
                ((IHidden)instance).Manipulate();
            }    
        }
    }
