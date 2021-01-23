				// your code with minor amends
		public DataTable RemoveDuplicateRows(DataTable dTable, string[] colNames)
		{
			// note that strongly typed dictionary has replaced the hash table + it uses custom comparer 
			var hTable = new Dictionary<DataRowInfo, string>();
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
			public override bool Equals(object obj)
			{
				if (ReferenceEquals(this, obj))
					return true;
				var other = obj as DataRowInfo;
				if (other == null)
					return false;
				return Equals(other);
			}
			private bool Equals(DataRowInfo other)
			{
				if (this.Values.Length != other.Values.Length)
					return false;
				for (int i = 0; i < this.Values.Length; i++)
				{
					if (AreObjectsEqual(this.Values[i], other.Values[i]))
						return false;
				}
				return true;
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
			public override int GetHashCode()
			{
				unchecked
				{
					int hashCode = 0;
					foreach (var value in this.Values)
					{
						hashCode = hashCode ^ ((value != null ? value.GetHashCode() : 0) * 397);
					}
					return hashCode;
				}
			}
		}
