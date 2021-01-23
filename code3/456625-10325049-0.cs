    dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value == null)
            return;
        string stringValue = (string)e.Value;
        stringValue = stringValue.ToLower();
        if (e.Value == "1")
        {
            e.Value = "string for one";
            e.FormattingApplied = true;
        }
    }
