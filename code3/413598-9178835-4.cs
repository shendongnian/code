    public class TextToolStripSeparator : ToolStripMenuItem
    {
        public override bool CanSelect
        {
            get { return DesignMode; }
        }
    }
