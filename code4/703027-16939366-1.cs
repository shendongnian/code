    public MainForm()
    {
        InitializeComponent();
        FormClosing += MainForm_FormClosing;
    }
    void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.Owner.Visible = true;
    }
    private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var childForm = new ChildForm();
        childForm.Show(this);
    }
