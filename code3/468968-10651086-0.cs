			Dictionary<string, float> columnNameAndValue = new Dictionary<string, float>();
			foreach (DataColumn column in entry.Columns)
			{
				if (column.ColumnName.Contains("weight") || column.ColumnName.Contains("amount"))
					//float column.ColumnName = 0;
					columnNameAndValue.Add(column.ColumnName, 0);
			}
