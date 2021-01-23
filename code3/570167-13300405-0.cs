			...
			var items = cn.Query("select * from SomeTable");
			grid.DataContext = ConvertToDataTable(items);
		}
		public DataTable ConvertToDataTable(IEnumerable<dynamic> items) {
			var t = new DataTable();
			var first = (IDictionary<string, object>)items.First();
			foreach (var k in first.Keys)
			{
				var c = t.Columns.Add(k);
				var val = first[k];
				if (val != null) c.DataType = val.GetType();
			}
			foreach (var item in items)
			{
				var r = t.NewRow();
				var i = (IDictionary<string, object>)item;
				foreach (var k in i.Keys)
				{
					var val = i[k];
					if (val == null) val = DBNull.Value;
					r[k] = val;
				}
				t.Rows.Add(r);
			}
			return t;
		}
