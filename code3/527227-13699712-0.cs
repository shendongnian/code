    //using System.Data.Common;
	public class LazyDataTable : DataTable {
		protected DbDataAdapter Adapter { get; set; }
		public LazyDataTable(DbDataAdapter a) {
			Adapter = a;
		}
		/// <summary>
		/// Save changes back to the database, using the DataAdapter
		/// </summary>
		public void Update() {
			Adapter.Update(this);
		}
		/// <summary>
		/// Fill this datatable using the SelectCommand in the DataAdapter
		/// The DB connection and query have already been set.
		/// </summary>
		public void Fill() {
			Adapter.Fill(this);
		}
		/// <summary>
		/// read and return one row at a time, using IEnumerable syntax
		/// (this example does not actually add the row to this table, 
		/// but that can be done as well, if desired.
		/// </summary>
		public IEnumerable<DataRow> LazyReadRows() {
			using (var reader = OpenReader()) {
				//Get the schema from the reader and copy it to this table.
				var schema = reader.GetSchemaTable();
				var values = new object[schema.Columns.Count];
				while (reader.Read()) {
					reader.GetValues(values);
					var row = schema.NewRow();
					row.ItemArray = values;
					yield return row;
				}
			}
		}
		/// <summary>
		/// Fill one row at a time, and return the new row.
		/// </summary>
		public DataRow ReadRow() {
			if (_reader == null || _reader.IsClosed) 
				_reader = OpenReader();
			//Get the schema from the reader and copy it to this table.
			if (this.Columns.Count == 0) 
				this.Columns.AddRange(_reader.GetSchemaTable().Columns.Cast<DataColumn>().ToArray());
			if (!_reader.Read()) {
				_reader.Dispose();
				return null;
			}
			var values = new object[_reader.FieldCount];
			_reader.GetValues(values);
			return this.Rows.Add(values);
		}
		private DbDataReader _reader = null;
		private DbDataReader OpenReader() {
			OpenConnect();
			return Adapter.SelectCommand.ExecuteReader();
		}
		private void OpenConnect() {
			var cn = Adapter.SelectCommand.Connection;
			if (cn.State == ConnectionState.Closed)
				cn.Open();
		}
		/// <summary>
		/// Change a Parameter in the SelectCommand, to filter which rows to retrieve.
		/// </summary>
		public void SetSelectParam(string name, object value) {
			var selparams = Adapter.SelectCommand.Parameters;
			selparams[name].Value = value;
		}
	}
