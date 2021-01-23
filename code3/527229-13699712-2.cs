    	static class Program {
		void GetPermissions() {
			ISource permissionSource = SourceManager.Sources.
				Where(s => "Permission".Equals(s.UniqueName)).First();
			var table = permissionSource.Table as LazyDataTable;
			table.SetSelectParam("PermissionName", "Admin");
			
			//If you want to fill ALL rows in one step:
			table.Fill(); 
			
			// OR If you want to fill one row at a time, and add it to the table:
			DataRow row;
			while(null != (row = table.ReadRow())) {
				//do something with each individual row. Exit whenever desired.
				Console.WriteLine(row["PermissionName"]);
			}
			
			// OR If you prefer IEnumerable semantics:
			DataRow row = table.LazyReadRows().FirstOrDefault(someValue.Equals(row["columnname"]));
			//OR use foreach, etc. Rows are still ONLY read one at a time, each time IEnumerator.MoveNext() is called.
			foreach (var row in table.LazyReadRows())
				if (row["someColumn"] == "someValue")
					DoSomething(row["anothercolumn"]);
		}
	}
