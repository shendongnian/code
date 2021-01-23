    var result = from s in Tables[Table_Sec].AsEnumerable()
                 where query.Contains(s["sectype"])
                 select new object[] 
                 {
                     s["id"],
                     s["name" ]
                 };
    DataTable dt = new DataTable();  
    dt.Columns.Add("id", typeof(string));
    dt.Columns.Add("name", typeof(string));
    foreach(var row in result)
    {
        dt.Rows.Add(row); 
    }
