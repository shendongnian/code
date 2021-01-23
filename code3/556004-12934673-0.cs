		// your code with minor amends
		public DataTable RemoveDuplicateRows(DataTable dTable, string[] colNames)
		{
            // note that strongly typed dictionary has replaced the hash table + it uses custom comparer 
			var hTable = new Dictionary<DataRowInfo, string>(new DataRowInfoComparer());
			var duplicateList = new ArrayList();
			//Add list of all the unique item value to hashtable, which stores combination of key, value pair.
			//And add duplicate item value in arraylist.
			foreach (DataRow drow in dTable.Rows)
			{
				var dataRowInfo = new DataRowInfo(drow, colNames);
				if (hTable.ContainsKey(dataRowInfo))
					duplicateList.Add(drow);
				else
					hTable.Add(dataRowInfo, string.Empty);
			}
			//Removing a list of duplicate items from datatable.
			foreach (DataRow dRow in duplicateList)
				dTable.Rows.Remove(dRow);
			//Datatable which contains unique records will be return as output.
			return dTable;
		}
		// Helper classes
		// contains values of specified columns
		internal sealed class DataRowInfo
		{
			public object[] Values { get; private set; }
			public DataRowInfo(DataRow dataRow, string[] columns)
			{
				Values = columns.Select(c => dataRow[c]).ToArray();
			}
		}
		// can compare two DataRowInfo instances
		internal sealed class DataRowInfoComparer : IEqualityComparer<DataRowInfo>
		{
			public bool Equals(DataRowInfo x, DataRowInfo y)
			{
				if (ReferenceEquals(null, y)) return false;
				if (ReferenceEquals(x, y)) return true;
				if (x.Values.Length != y.Values.Length)
					return false;
				for (int i = 0; i < x.Values.Length; i++)
				{
					if (AreObjectsEqual(x.Values[i], y.Values[i]))
						return false;
				}
				return true;
			}
			public int GetHashCode(DataRowInfo obj)
			{
				unchecked
				{
					int hashCode = 0;
					foreach (var value in obj.Values)
					{
						hashCode = hashCode ^ ((value != null ? value.GetHashCode() : 0) * 397);
					}
					return hashCode;
				}
			}
			private static bool AreObjectsEqual(object left, object right)
			{
				if (ReferenceEquals(left, right))
					return true;
				if (ReferenceEquals(left, null))
					return false;
				if (ReferenceEquals(right, null))
					return false;
				if (left.GetType() != right.GetType())
					return false;
				return left.Equals(right);
			}
		}
