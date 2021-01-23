    foreach (DataGridViewColumn column in dataGridView1.Columns)
    {
        if (column.HeaderText == "customer_id")
        {
            column.HeaderText = "my_title"
        }
    }
