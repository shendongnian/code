        class SomeClass
        {
            void DoIt()
            {
                var func = Class1.CreateCallFunc<MainWindow>("SomeMethod");
                Console.WriteLine(func(this));
            }
            public string SomeMethod()
            {
                return "it works!";
            }
        }
