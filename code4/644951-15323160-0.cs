        interface IHasName2
        {
            string Name2 { get; }
        }
        class Class1
        {
            string Name1;
            public Class1()
            {
                var withName2 = this as IHasName2;
                if (withName2 != null)
                {
                    Name1 = withName2.Name2;
                }
            }
        }
