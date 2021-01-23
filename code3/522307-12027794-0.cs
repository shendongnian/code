    protected void GenerateControls()
    {
        var table = new Table();
        var headerRow = new TableHeaderRow();
        var headerCell = new TableHeaderCell();
        headerCell.Text = "Name";
        headerRow.Cells.Add(headerCell);
        headerCell = new TableHeaderCell();
        headerCell.Text = "Price";
        headerRow.Cells.Add(headerCell);
        headerCell = new TableHeaderCell();
        headerRow.Cells.Add(headerCell);
        headerCell = new TableHeaderCell();
        headerRow.Cells.Add(headerCell);
        table.Rows.Add(headerRow);
    
        //Other Buttons
        foreach (Record r in Records)
        {
            var row = new TableRow();
    
            var cell = new TableCell();
            //Edit Button
            Button btn_Edit = new Button();
            btn_Edit.CssClass = "btn-edit";
            btn_Edit.ID = "btnEdit_" + r.ID;
            btn_Edit.Text = "Edit";
            btn_Edit.Command += new CommandEventHandler(EditRecord);
            btn_Edit.CommandArgument = r.ID.ToString();
            cell.Controls.Add(btn_Edit);
            row.Cells.Add(cell);
            table.Rows.Add(row);
        }
    
        ContentTemplateContainer.Controls.Add(table);
    }
