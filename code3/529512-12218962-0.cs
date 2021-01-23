        protected void Page_Load(object sender, EventArgs e)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Controls.Add(new TextBox());
            row.Cells.Add(cell);
            table.Rows.Add(row);
        }
