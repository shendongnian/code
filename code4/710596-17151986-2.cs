    public static class Math3D
    {
        internal static int s_Round;
        internal static double s_Epsilon;
        static Math3D ()
        {
            Round = 3;
        }
        public static double Epsilon
        {
            get
            {
                return ( s_Epsilon );
            }
        }
        public static int Round
        {
            get
            {
                return ( s_Round );
            }
            set
            {
                // TODO validate
                s_Round = value;
                s_Epsilon = Math.Pow ( 10, -s_Round );
            }
        }
    }
