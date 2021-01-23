    DataTable dt = new DataTable();
    dt.Columns.Add("ServerName", typeof(string));
    dt.Columns.Add("UserName", typeof(string));
    dt.Columns.Add("LearningGroup", typeof(string));
    
    dt.Rows.Add("ServA", "John", "First Group");
    dt.Rows.Add("ServA", "Kate", "First Group");
    dt.Rows.Add("ServA", "John", null);
    dt.Rows.Add("ServB", "Kate", null);
    dt.Rows.Add("ServB", "Kate", "Second Group");
    
    var tmpDT = (from x in dt.AsEnumerable()
    			 join f in dt.AsEnumerable() on new { UserName = x.Field<String>("UserName"), ServerName = x.Field<String>("ServerName") } equals new { UserName = f.Field<String>("UserName"), ServerName = f.Field<String>("ServerName") }
    			 where !string.IsNullOrEmpty(x.Field<String>("LearningGroup"))
    			 select x).Distinct();
