	IObservable<DataTable> q =
		from text in qPlugins.Result(query, qType, sensitive)
		from tempTable in Observable.Using(
			() => new GenericParserAdapter(),
			parser => Observable.Using(
				() => new StringReader(text),
				sr => Observable .Start<DataTable>(
					() =>
					{
						var rNum = new Random();
						parser.SetDataSource(sr);
						parser.ColumnDelimiter = Convert.ToChar(",");
						parser.FirstRowHasHeader = true;
						parser.MaxBufferSize = 4096;
						parser.MaxRows = 500;
						parser.TextQualifier = '\"';
						var tempTable = parser.GetDataTable();
						tempTable.TableName = qPlugins.Name.ToString();
						if (!tempTable.Columns.Contains("Query"))
						{
							DataColumn tColumn = new DataColumn("Query");
							tempTable.Columns.Add(tColumn);
							tColumn.SetOrdinal(0);
						}
						foreach (DataRow dr in tempTable.Rows)
							dr["Query"] = query;
						
						return tempTable;
					})))
		select tempTable;
