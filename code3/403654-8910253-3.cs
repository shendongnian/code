    protected void test(object sender, EventArgs e)
    {
        ddl2.Items.Clear();
        for (int i = 0; i < 4; i++)
            ddl2.Items.Add(new ListItem("Test" + ddl1.SelectedIndex));
    }
