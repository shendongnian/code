    private void bindGrid()
    {
        List <TestCode> list = new List<TestCode>();
        TestCode tt = new TestCode();
        list.Add(tt);
        list.Add(tt);
        list.Add(tt);
        list.Add(tt);
        list.Add(tt);
        list.Add(tt);
        list.Add(tt);
        list.Add(tt);
        list.Add(tt);
        this.dataGridView1.DataSource = list;
        this.dataGridView1.DataBind();
    }
