    private void button7_Click_3(object sender, EventArgs e)
    {
        var original = ((DataTable)dataGridView1.DataSource);
        var clone = original.Clone();
        var ordinal = original.Columns["Stringtext"].Ordinal;
        for (int i = 0; i < original.Rows.Count; i++)
        {
            var values = original.Rows[i].ItemArray;
            values[ordinal] = values[ordinal].ToString()
                .Replace(textBox6.Text, "_TEST_");
            clone.Rows.Add(values);
        }
        dataGridView1.DataSource = clone;
    }
