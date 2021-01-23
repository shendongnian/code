    void radGridView1_ValueChanged(object sender, EventArgs e)
    {
        if (radGridView1.CurrentColumn.Name == "MyCheckBoxColumnName")
        {
            radGridView1.EndEdit();
        }
    }
