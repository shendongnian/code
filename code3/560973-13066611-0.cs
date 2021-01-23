You can use [HeaderRow][1].Cells.Add property
foreach (GridViewRow gvr in GridView1.Rows)
{
   TableCell tbCell = new TableCell();
   CheckBox cb1 = new CheckBox();
   tbCell.Controls.Add(cb1);
   gvr.Cells.Add(tbCell);
}
TableCell tbCell = new TableCell();
CheckBox cb1 = new CheckBox();
tbCell.Controls.Add(cb1);
gvr.HeaderRow.Cells.Add(tbCell);
