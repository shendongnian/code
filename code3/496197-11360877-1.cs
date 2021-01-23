    class MyObjects : List<MyObject>
    {
        public MyObjects()
        {
            Add(new MyObject 
                { 
                    Services = new List<Service>()
                        {
                            new Service { ID = 1, Name = "foo" },
                            new Service { ID = 2, Name = "bar" },
                        }
                });
            Add(new MyObject
            {
                Services = new List<Service>()
                        {
                            new Service { ID = 3, Name = "baz" },
                            new Service { ID = 4, Name = "foo1" },
                            new Service { ID = 1, Name = "dup 1"}
                        }
            });
        }
    }
