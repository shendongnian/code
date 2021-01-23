	class dbFunctions
	{
		public static DataTable QueryString(string QueryStr)
		{
			var result = new DataTable();
			using(OleDbConnection con = new OleDbConnection(GlobalVar.strAccessConn))
			{
				con.Open();
				using(OleDbCommand cmd = new OleDbCommand(QueryStr, con))
					result.Load(cmd.ExecuteReader());
			}
			return result;
		}
	}
	
	private void button1_Click(object sender, EventArgs e)
	{
		var data = dbFunctions.QueryString("SELECT * FROM seriennummer;");
		foreach(var row in data.Rows)
			MessageBox.Show(row[1].ToString());
	}
