    public Form1() {
      InitializeComponent();
      speedSelector.Tag = speedSelector.Text;
      speedSelector.SelectedIndexChanged += new System.EventHandler(this.speedSelector_Changed);
      speedSelector.SelectionChangeCommitted += new System.EventHandler(this.speedSelector_Changed);    
      speedSelector.TextUpdate += new System.EventHandler(this.speedSelector_Changed);
    }
    private void speedSelector_Changed(object sender, EventArgs e) {
      if (validData(speedSelector.Text)) {
        speedSelector.Tag = speedSelector.Text;
      } else {
        speedSelector.Text = speedSelector.Tag.ToString();
      }
    }
    private static bool validData(string value) {
      bool result = false;
        // do your test here
      return result;
    }
