    public class ScrollableButton : Button
    {
        private bool _isScrolling;
    
        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            _isScrolling = true;
            base.OnMouseMove(mevent);
        }
    
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _isScrolling = false;
        }
    
        public bool IsScrolling { get; set; }
    
        protected override void OnClick(EventArgs e)
        {
            if (!_isScrolling)
                base.OnClick(e);
        }
    }
