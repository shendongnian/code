        abstract class Class1
        {
            string Name1;
            
            // instance property required to be implemented by deriving classes
            protected abstract string Name2 { get; }
            // instance constructor
            protected Class1()
            {
                // 'Name2' can be read already here (dangerous?)
                Name1 = Name2;
            }
        }
