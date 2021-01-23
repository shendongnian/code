    class GenericTest
    {
        public class Child { }
        public class X : Child { }
        public class Y : Child { }
        public class Z : Child { }
        private double FindPrice<T>(T l_Price_Breaks) where T : Child
        {
            return 2;
        }
        private void foobar()
        {
            X MyX = new X();
            double retValue = FindPrice(MyX);
        }
    }
