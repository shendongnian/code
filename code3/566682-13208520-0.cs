    DataView dvw = new DataView(ds.Tables[0]);
    DataTable table = dvw.ToTable(true, value);
    cmb.Items.Clear();
    cmb.Items.Add("Select");
    for (int intCount = 0; intCount < table.Rows.Count; intCount++)
    {
        cmb.Items.Add(table.Rows[intCount][value].ToString());
    }
    cmb.SelectedIndex = 0;
