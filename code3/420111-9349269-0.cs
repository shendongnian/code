    class SomeClass: IEquatable<SomeClass>
    {
        public string param1 { get; private set; }
        public string param2 { get; private set; }
        private SomeClass() { }
        public SomeClass(string param1, string param2)
        {
            this.param1 = param1;
            this.param2 = param2;
        }
        public bool Equals(SomeClass other)
        {
            return param1 == other.param1 && param2 == other.param2;
        }
    }
