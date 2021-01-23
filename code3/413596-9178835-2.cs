    public class TextToolStripSeparator : ToolStripMenuItem
    {
        public override bool CanSelect
        {
            get
            {
                return DesignMode;
            }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                value = value.Trim('-', ' ');
                base.Text = "---- " + value + " -------";
            }
        }
    }
