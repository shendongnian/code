    public struct Velosity
    {
        private double _value; // Value in m/s (SI system, use yours most frequently used)
        public Velosity(double value)
        {
            _value = value;
        }
        public double GetMS()
        {
            return _value;
        }
        public double GetKmH()
        {
            return _value*3.6;
        }
        //Other Get conversions...
        public static Velosity FromMS(double value)
        {
            return new Velosity(value);
        }
        public static Velosity FromKmH(double value)
        {
            return new Velosity(value/3.6);
        }
        //Other From conversions...
        public static implicit operator Velosity(double value)
        {
            return new Velosity(value);
        }
        public static implicit operator double(Velosity velosity)
        {
            return velosity._value;
        }
    }
    
    static void Main(string[] args)
    {
        var v = Velosity.FromMS(10) + Velosity.FromKmH(10);
        Velosity velosity = v;
        Console.WriteLine(v);
        Console.WriteLine(velosity.GetKmH());
        Console.WriteLine(velosity.GetMS());
        velosity += 10;
        Console.WriteLine(velosity.GetMS());
        Console.ReadKey();
    }
