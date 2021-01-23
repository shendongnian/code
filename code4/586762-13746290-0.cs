       class Program {
            static void Main(string[] args) {
                foo();
            }
    
            class FooBar : Attribute { }
    
            [FooBar]
            static extern void foo();
        }
