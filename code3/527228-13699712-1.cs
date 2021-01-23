    interface ISource {
		public DataTable Table { get; }
		string UniqueName { get; }
	}
	public class PermissionSource : ISource {
		/// <summary>
		/// Loads a DataTable with all of the information to load it lazily.
		/// </summary>
		public DataTable Table { 
			get { 
				const string SELECT_CMD = "SELECT * FROM [Permissions] WHERE ([PermissionName] IS NULL OR [PermissionName]=@p1) AND [OtherProperty]=@p2";
				var conn = new OleDbConnection("...ConnectionString...");
				var selectCmd = new OleDbCommand(SELECT_CMD, conn);
				selectCmd.Parameters.AddWithValue("p1", "PermissionName");
				selectCmd.Parameters.AddWithValue("p2", 0);
				var adapter = new OleDbDataAdapter(selectCmd);
				var builder = new OleDbCommandBuilder(adapter); //used to generate the UPDATE and DELETE commands...
				adapter.UpdateCommand = builder.GetUpdateCommand(); //etc.
				//Do NOT fill the table here. Instead, let the caller fill it.
				return new LazyDataTable(adapter);
			}
		}
		public string UniqueName { get { return "Permission"; } }
	}
