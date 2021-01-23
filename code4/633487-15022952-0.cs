    class ConstructorChaining
    {
        public string a;
        public string b;
        public int c;
    
        public ConstructorChaining(string astring, string anotherstring, int anint)
        {
            a = astring;
            b = anotherstring;
            c = anint;
        }
    
        public ConstructorChaining(string astring) : this(astring, astring, 2)
        {
        }
    }
