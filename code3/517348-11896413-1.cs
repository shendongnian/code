    protected HtmlTable dynamictable;
    protected TextBox tb = new TextBox();
    
    protected override void OnInit(EventArgs args)
    {
     base.OnInit(args);
     CreateTableRows();
    }
    
    private void CreateTableRows()
    {
     HtmlTableRow row = new HtmlTableRow();
     HtmlTableCell cell1 = new HtmlTableCell();
     HtmlTableCell cell2 = new HtmlTableCell();
     cell1.Controls.Add(new Label() { ID = LableID1, Text = Name });
     cell2.Controls.Add(tb });
     row.Cells.Add(cell1);
     row.Cells.Add(cell2);
     dynamictable.Rows.Add(row);
    }
    
    protected void OnClick(object sender, EventArgs args)
    {
     return tb.Text;
    }
