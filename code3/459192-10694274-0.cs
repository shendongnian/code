        public static PointF getPointOnCircle(PointF p1, PointF p2, Int32 radius)
        {
            PointF Pointref = PointF.Subtract(p2, new SizeF(p1));
            double degrees = Math.Atan2(Pointref.Y, Pointref.X);
            double cosx1 = Math.Cos(degrees);
            double siny1 = Math.Sin(degrees);
            double cosx2 = Math.Cos(degrees + Math.PI);
            double siny2 = Math.Sin(degrees + Math.PI);
            return new PointF((int)(cosx1 * (float)(radius) + (float)p1.X), (int)(siny1 * (float)(radius) + (float)p1.Y));
        }
    
