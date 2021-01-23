    class TopClass
        {
            public String getHello()
            {
                return "Hello";
            }
            public virtual String getWorld()
            {
                return "World";
            }
        }
        class ChildClass : TopClass
        {
            public new String getHello()
            {
                return "Hi";
            }
            public override string getWorld()
            {
                return "Earth";
            }
        }
