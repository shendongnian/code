    DataTable dt = new DataTable();
    dt.Columns.Add("ID", typeof(int));
    dt.Columns.Add("CategoryName");
    dt.Rows.Add(0, "Select");
    cmbCategory.DisplayMember = "CategoryName";
    cmbCategory.ValueMember = "ID";
    cmbCategory.DataSource = dt;
    dt.Rows.InsertAt(dt.NewRow(), 0);
    cmbCategory.SelectedIndex = 0;
