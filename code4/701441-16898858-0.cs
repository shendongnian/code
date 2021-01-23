       TableCell cell = new TableCell();
       CheckBox box = new CheckBox();
       box.Check += new EventHandler(Checked_Changed);
       cell.Controls.Add(box);
       gvr.Cells.Add(cell);
