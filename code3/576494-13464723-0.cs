     public class ListThreeColumns
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public Color Color { get; set; }
        
        public override ToString()
        {
             return string.Format("X={0}, Y={1}, Color=({2};{3};{4})", 
                 this.XCoord , this.YCoord , Color.R,Color.G,Color.B );
        }
    }
