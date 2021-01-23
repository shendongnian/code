    eval.Run(@"using System;
        public class MyClass{
            public void DoSomething() {
                Console.WriteLine(""hello from DoSomething!"");
            }
        }
    ");
    eval.Run(@"new MyClass().DoSomething();");
