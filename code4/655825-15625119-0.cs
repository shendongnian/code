    public Form1() {
      InitializeComponent();
      toolStripDropDownButton1.MouseEnter += toolStripDropDownButton1_MouseEnter;
    }
    void toolStripDropDownButton1_MouseEnter(object sender, EventArgs e) {
      toolStripDropDownButton1.ShowDropDown();
    }
