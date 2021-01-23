        Table tbl = new Table();
        tbl.ID = "table1";
        placeHolder.Controls.Add(tbl);
        for (int row = 0; row < 5; row++)
        {
            TableRow rw = new TableRow();
            TableCell cell = new TableCell();
            Label text = new Label();
            text.Text = "text";
            cell.Controls.Add(text);
            rw.Cells.Add(cell);
            tbl.Controls.Add(rw);
        }
