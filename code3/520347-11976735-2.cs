    class SmallRectangle
    {
        public byte x { get; set; }
        public byte y { get; set; }
        public SmallRectangle(byte inx, byte iny)
        {
           x = inx;
           y = iny;
        }
        public static explicit operator SmallRectangle(Microsoft.Xna.Framework.Rectangle big)
        {
            SmallRectangle small = new SmallRectangle((byte)big.x, (byte)big.y);
    
            return small;
        }
        public WriteToFile(FileStream out)
        {
           //....
        }
    }
