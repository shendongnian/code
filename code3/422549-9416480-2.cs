    public partial class Form1 : Form {
      Panel backPanel;
      Panel topPanel;
      public Form1() {
        InitializeComponent();
        backPanel = new Panel();
        backPanel.Dock = DockStyle.Fill;
        backPanel.AutoScrollMinSize = new Size(0, 1000);
        this.Controls.Add(backPanel);
        topPanel = new Panel();
        topPanel.Height = 64;
        topPanel.Dock = DockStyle.Top;
        this.Controls.Add(topPanel);
      }
    }
