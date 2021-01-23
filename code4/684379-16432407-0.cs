    Table tbl= new Table();
    for (int rowItr = 0; rowItr < 3; rowItr++)
    {
        TableRow imageRow = new TableRow();
        for (int colItr = 0; colItr < 4; colItr++)
        {
            
            System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
            image.ImageUrl = "~/ShowTile.ashx?SheetId=" + SheetGUID + "&Scale=" + 3
                + "&XCoord=" + colItr + "&YCoord=" + rowItr;
            TableCell imageCell = new TableCell();
            imageRow.Cells.Add(imageCell);            
        }
        tbl.Rows.Add(imageRow);
    }
    placeholder1.Controls.Add(tbl);
