    public class ToolStripContainerFix : ToolStripContainer
    {
        public ToolStripContainerFix()
            : base()
        {
            this.TopToolStripPanel.MouseLeave += TopToolStripPanel_MouseLeave;
        }
        void TopToolStripPanel_MouseLeave(object sender, EventArgs e)
        {
            this.TopToolStripPanel.SuspendLayout();
        }
    }
