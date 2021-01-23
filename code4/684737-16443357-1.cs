			foreach (DataRow statementRow in ds.Tables["statement"].Rows)
			{
				var detail = new DataView(ds.Tables["domestic"])
				{
					RowFilter = String.Format("statementnumber = {0}", statementRow["statementnumber"]),
					Sort = "" // optional
				};
                               
				reportDoc.SetDataSource(detail);
                                ....
                          }
