Private void GridView3_RowDataBound(object sender,EventArgs e)
{
if(e.Row.RowState == DataControlState.DataRow)
{
foreach(string nm in name)
{
e.Rows.Cells.Add(name);
}
}
}
