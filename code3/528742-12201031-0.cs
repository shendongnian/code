    public Form1() {
      InitializeComponent();
      splitContainer1.Panel1.MouseClick += Panel_MouseClick;
      splitContainer1.Panel2.MouseClick += Panel_MouseClick;
      splitContainer2.Panel1.MouseClick += Panel_MouseClick;
      splitContainer2.Panel2.MouseClick += Panel_MouseClick;
      splitContainer3.Panel1.MouseClick += Panel_MouseClick;
      splitContainer3.Panel2.MouseClick += Panel_MouseClick;
      splitContainer4.Panel1.MouseClick += Panel_MouseClick;
      splitContainer4.Panel2.MouseClick += Panel_MouseClick;
    }
    void Panel_MouseClick(object sender, MouseEventArgs e) {
      SplitterPanel sp = sender as SplitterPanel;
      SplitContainer sc = sp.Parent as SplitContainer;
      MessageBox.Show(sc.Name + " - " + sp.Tag.ToString());
    }
