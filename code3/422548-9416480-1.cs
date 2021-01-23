    public partial class Form1 : Form {
      Panel backPanel;
      Panel floatPanel;
      public Form1() {
        InitializeComponent();
        floatPanel = new Panel();
        floatPanel.BorderStyle = BorderStyle.FixedSingle;
        floatPanel.SetBounds(0, 0, 128, 64);
        this.Controls.Add(floatPanel);
        backPanel = new Panel();
        backPanel.Dock = DockStyle.Fill;
        backPanel.AutoScrollMinSize = new Size(0, 1000);
        this.Controls.Add(backPanel);
      }
    }
