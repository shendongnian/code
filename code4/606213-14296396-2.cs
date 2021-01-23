    class derived : iInterface3
    {
        readonly double[] d = new double[5];
        public int MyProperty
        {
            get
            {
                return 5;
            }
            set
            {
                throw new Exception();
            }
        }
    
        public int iProperty
        {
            get
            {
                return 5;
            }
        }
    
        public double this[int x]
        {
            set
            {
                d[x] = value;
            }
        }
    }
    class derived2 : derived
    {
    
    }
    interface iInterface
    {
        int iProperty
        {
            get;
        }
        double this[int x]
        {
            set;
        }
    }
    interface iInterface2 : iInterface
    { }
    interface iInterface3 : iInterface2
    { }
