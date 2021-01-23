    [System.ComponentModel.DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All]
    public class ToolStripSimpleUserControl : ToolStripControlHost
    {
        public ToolStripSimpleUserControl ()
            : base(new SimpleUserControl())
        {
        }
        public SimpleUserControl StripSimpleUserControl
        {
            get { return Control as SimpleUserControl; }
        }
        
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // not thread safe!
            if (e != null)
            {
                this.StripSimpleUserControl.Invalidate();
            }
        }
    }
