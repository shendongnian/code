    private void ConvertGridToTable()
    {
        if (Datatabledt.Rows.Count > 0)
        { }
        Datatabledt = dtData.Clone();
        foreach (DataGridViewRow gr in YOURGRIDVIEW.SelectedRows)
        {
            DataRow dc = Datatabledt.NewRow();
            dc["KEY-FIELD"] = Int32.Parse(gr.Cells[0].Value.ToString());
            .....
            Datatabledt.Rows.Add(dc);
        }
        Datatabledt.AcceptChanges();
    }
