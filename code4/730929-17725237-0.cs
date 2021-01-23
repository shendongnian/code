    public void AddAttributeValue(string attribute, string value)
    {
        int n = dataGridView1.Rows.Add();
        dataGridView1.Rows[n].Cells[0].Value = attribute;
        dataGridView1.Rows[n].Cells[1].Value = value;
    }
