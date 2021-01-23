    .... Form()
    {
    this.InitializeComponent();
    treeView1.EnabledChanged += (s, o) =>
    {
        treeView1.BackColor = treeView1.Enabled ? Color.White : SystemColors.Control;
    };
    ....
    }
