    using System;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                var test = new myNode();
                Console.WriteLine(test);
            }
        }
        class myNode
        {
            public SyntaxNode originalNode = new SyntaxNode{Name = "SyntaxNode"};
            public override string ToString()
            {
                return print(originalNode); // This calls print(BaseClassExtention Class)
            }
            string print(BaseClassExtention Class) // <= This gets called.
            {
                return Class.Name;
            }
            string print(BaseClass b)
            {
                return b.ToString();
            }
        }
        class BaseClass
        {}
        class BaseClassExtention : BaseClass
        {
            public string Name { get; set; }
        }
        class SyntaxNode: BaseClassExtention
        {
    
        }
    }
