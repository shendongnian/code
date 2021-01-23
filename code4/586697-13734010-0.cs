    public class PaintingCanvas : Control {
        
        private Bitmap _canvas = new Bitmap();
        
        private Boolean _inOp; // are we in a mouse operation?
        private Point _opStart; // where the current mouse operation started
        private Point _opEnd; // where it ends
        
        public override void OnPaint(PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.DrawImage( _canvas ); // draw the current state
            
            if( _inOp ) {
                // assuming the only operation is to draw a line
                g.DrawLine( _opStart, _opEnd );
            }
        }
        
        protected override OnMouseDown(Point p) {
            _inOp = true;
            _opStart = _opEnd = p;
        }
        protected override OnMouseMove(Point p) {
            _opEnd = p;
            this.Invalidate(); // trigger repainting
        }
        protected override OnMouseUp(Point p) {
            using( Graphics g = Graphics.FromImage( _bitmap ) ) {
                g.DrawLine( _opStart, _opEnd ); // a permanent line
            }
            _inOp = false;
        }
    }
