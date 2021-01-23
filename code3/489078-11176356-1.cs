StringBuilder multiLine = new StringBuilder();
foreach (DataGridViewRow r in dgvSm.Rows)
{
 if (!r.IsNewRow)
 {
  if (r.Cells.Count &gt; 0)
  {
   multiLine.Append(r.Cells[0].Value.ToString()); //first separated
   for (int i = 1; i &lt; r.Cells.Count; ++i)
   {
    singleLine.Append(','); //between values
    singleLine.Append(r.Cells[i].Value.ToString());
   }
   multiLine.AppendLine();
  }
 }
}
