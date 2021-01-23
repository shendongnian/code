    public class MyRectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Rotation { get; private set; }
        public Coord Center { get; private set; }
        public Coord TopLeft { get; private set; }
        public Coord TopRight { get; private set; }
        public Coord BottomLeft { get; private set; }
        public Coord BottomRight { get; private set; }
    
        public MyRectangle(Coord origin, double length, double width)
        {
            Length = length;
            Width = width;
            Center = origin;
    
            BottomLeft = new Coord(Center.X - Width / 2, Center.Y - Length / 2);
            BottomRight = new Coord(Center.X + Width / 2, Center.Y - Length / 2);
            TopLeft = new Coord(Center.X - Width / 2, Center.Y + Length / 2);
            TopRight = new Coord(Center.X + Width / 2, Center.Y + Length / 2);
        }
    
        private void Move(Coord c)
        {
    
            InitCorners(new Coord((c.X - Center.X), (c.Y - Center.Y)));
            Center.X = Center.X + (c.X - Center.X);
            Center.Y = Center.Y + (c.Y - Center.Y);
        }
    
        private void InitCorners(Coord c)
        {
            BottomRight.X = (BottomRight.X + c.X );
            BottomRight.Y = (BottomRight.Y + c.Y);
    
            BottomLeft.X = (BottomLeft.X + c.X);
            BottomLeft.Y = (BottomLeft.Y + c.Y);
    
            TopRight.X = (TopRight.X + c.X);
            TopRight.Y = (TopRight.Y + c.Y);
    
            TopLeft.X = (TopLeft.X + c.X);
            TopLeft.Y = (TopLeft.Y + c.Y);
        }
    
        public void Rotate(double qtyRadians)
        {
            //Move center to origin
            Coord temp_orig = new Coord(Center.X, Center.Y);
            Move(new Coord(0, 0));
    
            BottomRight = RotatePoint(BottomRight, qtyRadians);
            TopRight = RotatePoint(TopRight, qtyRadians);
            BottomLeft = RotatePoint(BottomLeft, qtyRadians);
            TopLeft = RotatePoint(TopLeft, qtyRadians);
                
            //Move center back
            Move(temp_orig);
        }
            
        Coord RotatePoint(Coord p, double qtyRadians)
        {
            Coord temb_br = new Coord(p.X, p.Y);
            p.X = temb_br.X * Math.Cos(qtyRadians) - temb_br.Y * Math.Sin(qtyRadians);
            p.Y = temb_br.Y * Math.Cos(qtyRadians) + temb_br.X * Math.Sin(qtyRadians);
    
            return p;
        }
    }
    
    [DebuggerDisplay("({X},{Y})")]
    public class Coord
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Coord(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
