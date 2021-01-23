    public class ToolStripContainerFix : ToolStripContainer
    {
        public ToolStripContainerFix()
            : base()
        {
            this.TopToolStripPanel.MouseLeave += TopToolStripPanel_MouseLeave;
            this.TopToolStripPanel.MouseEnter += TopToolStripPanel_MouseEnter;
        }
        void TopToolStripPanel_MouseLeave(object sender, EventArgs e)
        {
            this.TopToolStripPanel.SuspendLayout();
        }
        void TopToolStripPanel_MouseEnter(object sender, EventArgs e)
        {
            this.TopToolStripPanel.ResumeLayout();
        }
    }
