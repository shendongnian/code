    public class HAControlBase : Control
    {
        protected virtual void OnPaintPre(PaintEventArgs e) { }
        protected virtual void OnPaintPost(PaintEventArgs e) { }
        internal virtual void OnPaintImpl(PaintEventArgs e) {
            base.OnPaint(e);
        }
        protected sealed override OnPaint(PaintEventArgs e) {
            OnPaintPre(e);
            OnPaintImpl(e);
            OnPaintPost(e);
        }
    }
    public class HAControl : HAControlBase
    {
        internal sealed override void OnPaintImpl(PaintEventArgs e) {
            OnPaint(e);
        }
        protected new virtual void OnPaint(PaintEventArgs e) {
            base.OnPaintImpl(e);
        }
    }
