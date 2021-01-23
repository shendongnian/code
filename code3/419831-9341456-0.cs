    BindingList<object> bList = new BindingList<object>();
    
    private void button1_Click(object sender, EventArgs e)
    {
        bList.Add(new { Name = "Foo", Gender = "Bar" });
        dataGridView1.DataSource = bList;
    }
