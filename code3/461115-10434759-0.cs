    TableCell cell = e.Item.Cells[0];
    if (cell.Controls.Count > 0)
    {
       cell.Controls[0].Visible = false;
    }
