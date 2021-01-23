    GridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    DataGridViewRow row = GridView1.SelectedRows[0];
    DataRow dRow = (DataRow)row.DataBoundItem;
    dt.Rows.Remove(dRow);
    Adapter.Update(dt);
