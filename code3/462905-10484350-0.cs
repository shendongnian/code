    public AppMenuItem(string path, string name)
    {
        InitializeComponent();
        label1.Text = name;
        this.path = path;
        pictureBox1.Image = ShortcutsHelper.GetIcon(path);
        ToolTip tt = ToolTip();
        tt.SetToolTip(label1, name);
    }
