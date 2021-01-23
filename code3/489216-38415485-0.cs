    public class Block
    {
        private static Rectangle m_drawRectangle;
        public virtual Rectangle drawRectangle
        {
            get 
                {
                     if(m_drawRectangle == null) m_drawRectangle = new Rectangle(0, 0, 32, 32); 
                     return m_drawRectangle; 
                }
        }
    }
    
    public class BlockX : Block 
    {
        private static Rectangle m_drawRectangle = new Rectangle(0, 0, 32, 32);
        public override Rectangle drawRectangle
        {
            get 
                {
                     if(m_drawRectangle == null) m_drawRectangle = new Rectangle(0, 0, 32, 32); 
                     return m_drawRectangle; 
                }
        }
    }
