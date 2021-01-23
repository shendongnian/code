    using System;
    
    namespace _2DEnum
    {
        public class Example
        {
            public void BuildCar(Cars car)
            {
                GC.KeepAlive(car);
            }
    
            public void ExampleUse()
            {
                BuildCar(Cars.Ferrari.Enzo);
            }
        }
    
        public sealed class Cars
        {
            private readonly string _value;
    
            private Cars(string value)
            {
                if (ReferenceEquals(value, null))
                {
                        throw new ArgumentNullException("value");
                }
                else
                {
                    _value = value;
                }
            }
    
            public override string ToString()
            {
                return _value;
            }
    
            public static class Ferrari
            {
                private static readonly Cars _California = new Cars("California");
                private static readonly Cars _Enzo = new Cars("Enzo");
                private static readonly Cars _Testarossa = new Cars("Testarossa");
    
                public static Cars California
                {
                    get { return Ferrari._California; }
                }
    
                public static Cars Enzo
                {
                    get { return Ferrari._Enzo; }
                }
    
                public static Cars Testarossa
                {
                    get { return Ferrari._Testarossa; }
                }
            }
    
            public static class Ford
            {
                private static readonly Cars _Corsair = new Cars("Corsair");
                private static readonly Cars _Cortina = new Cars("Cortina");
                private static readonly Cars _Galaxy = new Cars("Galaxy");
                private static readonly Cars _GT = new Cars("GT");
    
                public static Cars Corsair
                {
                    get { return Ford._Corsair; }
                }
    
                public static Cars Cortina
                {
                    get { return Ford._Cortina; }
                }
    
                public static Cars Galaxy
                {
                    get { return Ford._Galaxy; }
                }
    
                public static Cars GT
                {
                    get { return Ford._GT; }
                }
            }
        }
    }
