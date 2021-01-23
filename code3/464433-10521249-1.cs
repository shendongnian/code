    class Program
    {
	
        static void Main(string[] args)
        {
			DataTable dt = new DataTable("test");
			dt.Columns.Add("SOME_COL", typeof(string));
			dt.Rows.Add("AABCDEFG");
			dt.Rows.Add("AZBCDEFG");
			dt.Rows.Add("AZZBCDEFG");
			dt.Rows.Add("ABC");
			Regex r = new Regex("A\\wBCDE");
			DataView dv 
			   = (from t in dt.AsEnumerable()
				  where r.IsMatch(t.Field<string>("SOME_COL"))
				 select t).AsDataView();
			foreach(DataRowView row in dv)
			{
				Console.WriteLine(row[0]);
			}
 
		}
		
    }
