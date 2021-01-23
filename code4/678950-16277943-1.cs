    if (e.Item.ItemType == ListViewItemType.DataItem ||e.Item.ItemType == ListViewItemType.InsertItem||e.Item.ItemType == ListViewItemType.EmptyItem)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("DECLAREDVALUE");
        DataRow dr = dt.NewRow();
        dr["DECLAREDVALUE"] = "hello";
        dt.Rows.Add(dr);
        ((GridView)(e.Item.FindControl("itemsGridView"))).DataSource = dt;
        ((GridView)(e.Item.FindControl("itemsGridView"))).DataBind();
    }
