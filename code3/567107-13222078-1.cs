    class Monitor {
        DoubleWrap v;
        public Monitor(DoubleWrap x) { v = x; }
        public watch() { Console.WriteLine("Value is: " + v.Value); }
    }
