    public class ExtendedControl : Control
    {
        private Rectangle displayRectangle;
    
        protected override Rectangle DisplayRectangle
        {
            get { return this.displayRectangle; }
        }
    
        public void SetDisplayRectangle(Rectangle rect)
        {
            this.displayRectangle = rect;
        }
    
        public ExtendedControl()
        {
            this.displayRectangle = base.DisplayRectangle;
        }
    }
