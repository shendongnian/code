    public class Line
    {
        public Point P1 {get;set;}
        public Point P2 {get;set;}
        public double Length
        {
            get
            {
                return Math.Sqrt( 
                    Math.Pow( P2.X - P1.X, 2 ) + 
                    Math.Pow( P2.X - P1.X, 2 ) 
                );
            }
        }
    }
