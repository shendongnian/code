    public static class Class1
    {
        public static ISomething something;
        public static ISomeConstructedClass SomeConstructedClass
        {
            get
            {
                if (something == null) {
                    something = (ISomething)Class2.GetSomething("something");
                }
                return something.SomeConstructedClass;
            }
        }
    }
