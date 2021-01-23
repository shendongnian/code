        foreach (DataRow statementRow in ds.Tables["statement"].Rows)
        {
            var detail = GetFilteredTable(ds.Tables["domestic"], statementRow["statementNumber"]);
            
            reportDoc.SetDataSource(detail);
                            ....
        }
		public DataTable GetFilteredTable(DataTable dt, object statementNumber)
		{
			var detailRows = dt.Select(String.Format("statementnumber = {0}", statementNumber));
			var filteredDt = dt.Clone();
			foreach (var detailRow in detailRows)
			{
				filteredDt.Rows.Add(detailRow.ItemArray);
			}
			return filteredDt;
		}
