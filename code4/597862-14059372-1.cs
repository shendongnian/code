	//--------- inside the try block of your event handler -----------//
			var row = (sender as DataGridView).Rows[e.RowIndex];
			object objId = row.Cells["column_ID"].Value;
			object objMachine = row.Cells["column_Machine"].Value;
			// place a breakpoint on the line below, 
                        // so you can inspect the "obj..." values above to see
                        // if they are DBNull or not.
			var id_riga = objId.FromDb<Int64>();
			var id_macchina = objMachine.FromDb<Int32>();
	//-----------continue your code here---------//
	//----outside the form class, possibly in a separate file -----/
	static class DbObjectExtensions {
		public static T FromDb<T>(this object dbObj, T defaultValueIfNull = default(T)) where T : IConvertible {
			if (Convert.IsDBNull(dbObj))
				return defaultValueIfNull;
			if (dbObj is T)
				return (T)dbObj;
			return (T)Convert.ChangeType(dbObj, typeof(T));
		}
	}
