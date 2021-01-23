    private Database viewlist = new Database();
    private void LoadList()
    {
        listBox1.Items.Clear();
        listBox1.Items.AddRange(viewlist.listPickups.ToArray());
    }
    private void Summary_Load(object sender, EventArgs e)
    {
        LoadList();
    }
