    // A line in the form Ax+By=C from 2 points
    public struct Ray
    {
        public readonly float A;
        public readonly float B;
        public readonly float C;
        public Ray(PointF one, PointF two)
        {
           this.A = two.y - one.y;
           this.B = one.x - two.x;
           this.C = (this.A * one.x) + (this.B * two.x); 
        }
    }
