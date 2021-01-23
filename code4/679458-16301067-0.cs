    using System;
    
    struct Maybe<T>
    {
        private readonly bool hasValue;
        public bool HasValue { get { return hasValue; } }
        
        private readonly T value;
        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new InvalidOperationException();
                }
                return value;
            }
        }
        
        public Maybe(T value)
        {
            this.hasValue = true;
            this.value = value;
        }
        
        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }
    }
    
    class Test
    {
        static void DoSomeCalc(Maybe<double> x = default(Maybe<double>),
                               Maybe<double> y = default(Maybe<double>))
        {
            Console.WriteLine(x.HasValue ? "x = " + x.Value : "No x");
            Console.WriteLine(y.HasValue ? "y = " + y.Value : "No y");
        }
        
        static void Main()
        {
            Console.WriteLine("First call");
            DoSomeCalc(x: 10);
            
            Console.WriteLine("Second call");
            DoSomeCalc(y: 20);
        }
    }
