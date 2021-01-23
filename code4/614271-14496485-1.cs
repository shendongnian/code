      `public struct Point
        {
            public int XLocation { get; set; }
            public int YLocation { get; set; }
        }`
        public static Point Location(int p_1, int p_2, int p_3, int p_4) 
        {    
            return new Point 
            {
              XLocation  = p_2 - p_1;
              YLocation = p_4-p_3;
            }      
        }
