    class derived : iInterface3
    {
        double[] d = new double[5];
    
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
