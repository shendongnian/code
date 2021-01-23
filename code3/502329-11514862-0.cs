    private void progHider_Load(object sender, EventArgs e)
    {
        List.DataSource = getList();
    }
    private void btnrefresh_Click(object sender, EventArgs e)
    {
        List.DataSource = getList();
    }
