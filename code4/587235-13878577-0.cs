		public DataTable TextBlocks
		{
			get
			{
				Converter converter = new DifferenceToTextConverter();
				DataTable table = new DataTable();
				foreach (DataColumn col in this.Model.Columns)
					table.Columns.Add(col.ColumnName, typeof(TextBlock));
				foreach (DataRow row in this.Model.Rows)
				{
					DataRow addedRow = table.NewRow();
					for (int col = 0; col < row.ItemArray.Length; col++)
					{
						addedRow[col] = converter.ConvertTo(row[col]);
					}
					table.Rows.Add(addedRow);
				}
				return table;
			}
		}
