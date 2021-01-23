    public class Block
    {
        private static Rectangle m_drawRectangle = new Rectangle(0, 0, 32, 32);
        public virtual Rectangle drawRectangle
        {
            get { return m_drawRectangle; }
        }
    }
    public class BlockX : Block 
    {
        private static Rectangle m_drawRectangle = new Rectangle(0, 0, 32, 32);
        public override Rectangle drawRectangle
        {
            get { return m_drawRectangle; }
        }
    }
