        protected DataTable ConvertToDataTable()
        {
            DataTable TempTable = new DataTable();
            TempTable = dtCompanies.Clone();
 
            foreach (GridViewRow row in gvCompanies.Rows)
            {
                 DataRow TempRow = TempTable.NewRow();
        
                 for (int i = 0; i < row.Cells.Count; i++)
                 {
                     if (row.Cells[i].Controls[0].GetType().Equals(typeof(DataBoundLiteralControl)))
                     {
                         TempRow[i] = ((DataBoundLiteralControl)row.Cells[i].Controls[0] as DataBoundLiteralControl).Text;
                     }
                     else if (row.Cells[i].Controls[0].GetType().Equals(typeof(TextBox)))
                     {
                         TempRow[i] = ((TextBox)row.Cells[i].Controls[0]).Text;
                     }
                 }
                 TempTable.Rows.Add(TempRow);
            }
            return TempTable;
        }
