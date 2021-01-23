        private MyClass(IWhatEver a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            // the cool code comes here, I could put it into
            // the CallMeFromConstructor method but is there another way?
        }
        public MyClass(IWhatEver a, ISomeThingElse b) : this(a)
        {
            if (b == null)
            {
                throw new ArgumentNullException("b");
            }
        }
    
        public MyClass(IWhatEver a, IAnotherOne b) : this(a)
        {
            if (b == null)
            {
                throw new ArgumentNullException("b");
            }
        }
