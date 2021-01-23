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
    
        public ConstructorChaining(string astring) : this("fff", astring, 2)
        {
            //This code will be executed After your 3 param constructor. 
            a = astring;
        }
    }
