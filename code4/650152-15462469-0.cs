        class XyzParent
        {
            protected static int FieldOne;
            protected int FieldTwo;
            static XyzParent()
            {
                FieldOne = 1;
                Console.WriteLine("parent static");
            }
            internal XyzParent()
            {
                FieldOne = 10;
                FieldTwo = 20;
                Console.WriteLine("parent instance");
            }
        }
        class XyzChild : XyzParent
        {
            static XyzChild()
            {
                FieldOne = 100;
                Console.WriteLine("child static");
            }
            internal XyzChild()
            {
                FieldOne = 1000;
                FieldTwo = 2000;
                Console.WriteLine("child instance");
            }
        }
