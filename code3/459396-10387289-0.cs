    public UserControl1() {
      InitializeComponent();
      panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
    }
    void panel1_MouseDown(object sender, MouseEventArgs e) {
      if (!this.Focused)
        this.Focus();
    }
