    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) RecreateTable();
    }
    private void RecreateTable()
    {
        var selected = this.check.Items.Cast<ListItem>().Where(i => i.Selected);
        foreach (var item in selected)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            Label lbl = new Label();
            lbl.Text = item.Text;
            cell.Controls.Add(lbl);
            row.Cells.Add(cell);
            this.TblCheck.Rows.Add(row);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //RecreateTable();
    }
