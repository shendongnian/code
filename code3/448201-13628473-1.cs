    class Vector
    {
        private double[] m_data;
        public int Dimension {get;set;}
        private bool m_bIsConstant = false;
        ...
        public double this[int i]
        {
            get {return m_data[i];}
            set 
            {
               if (!m_bIsConstant)
               {
                    m_data[i] = value;
               }
            }
        }
        ...
        public static Vector Zero(int n)
        {
            Vector v = new Vector(n);
            for (int i = 0; i < n; i++)
            {
                v[i] = 0.0;
            }
            
            v.m_bIsConstant = true;
            return v;
         }
         ...
    }
