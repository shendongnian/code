    List<string> rows = new List<string>(
    new string[] { "Row 1", "Row 2", "Row 3" });
    rows.Clear();
    if (rows.Count > 0)
    {
        gv.DataSource = rows;
        gv.DataBind();
    }
    else
    {
        rows.Add("");
        gv.DataSource = rows;
        gv.DataBind();
        gv.Rows[0].Visible = false;
    }
