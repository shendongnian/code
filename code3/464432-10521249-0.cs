    DataTable dt = new DataTable("test");
    dt.Columns.Add("SOME_COL", typeof(string));
     
    dt.Rows.Add("AABCDEFG");
    dt.Rows.Add("AZZBCDEFG");
    
    Regex r = new Regex("A Regex here");
    
    DataView dv = (from t in dt.AsEnumerable()
    		   where r.IsMatch(t.Field<string>("SOME_COL"))
    		   select t).AsDataView();
