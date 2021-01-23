    DataSourceSelectArguments args = new DataSourceSelectArguments();
    DataView view = (DataView)SqlDataSource1.Select(args);
    DataTable dt = view.ToTable();
    DropDownList[] array = { kw1, kw2, kw3, kw4, kw5, kw6 };
    int i;
    for (i = 0; i < dt.Rows.Count;i++ )
        array[i].SelectedItem.Text = dt.Rows[i][0].ToString();
    // If array length is greater than rows in datasource then. Remaining Dropdowns
    // will get text N/A --- Now i=dt.Rows.Count
    for (; i < array.Length; i++)
        array[i].SelectedItem.Text = "N/A";
