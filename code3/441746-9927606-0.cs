    public partial class Form1 : Form {
      public Form1() {
        InitializeComponent();
        this.IsMdiContainer = true;
        ToolStripPanel leftPanel = new ToolStripPanel() { Dock = DockStyle.Left };
        ToolStripPanel topPanel = new ToolStripPanel() { Dock = DockStyle.Top };
        this.Controls.Add(leftPanel);
        this.Controls.Add(topPanel);
        ToolStrip ts = new ToolStrip() { Dock = DockStyle.Fill };
        ToolStripButton tsb = new ToolStripButton("Test", SystemIcons.Application.ToBitmap());
        ts.Items.Add(tsb);
        topPanel.Controls.Add(ts);
      }
    }
