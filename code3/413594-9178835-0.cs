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
                if (!value.StartsWith("--- ") && !value.EndsWith(" ---")) {
                    base.Text = "--- " + value + " ---";
                } else {
                    base.Text = value;
                }
            }
        }
    }
