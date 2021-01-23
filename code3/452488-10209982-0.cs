    public class PanelMenuItem : ToolStripControlHost {
      Panel panel;
      public PanelMenuItem()
        : base(new Panel()) {
        panel = Control as Panel;
        Visible = true;
        Enabled = true;
        panel.AutoSize = false;
        panel.Size = new Size(100, 50);
        panel.MinimumSize = panel.Size;
      }
    }
