        class SomeClass
        {
            void DoIt()
            {
                var func = CreateCallFunc<SomeClass>("SomeMethod");
                Console.WriteLine(func(this));
            }
            public string SomeMethod()
            {
                return "it works!";
            }
        }
