    List<Tuple<string,string>> values = new List<Tuple<string,string>>();
    
    foreach (DataTable dt in ds.Tables){
    	foreach (DataRow r in dt.Rows){
           string text = r[1] + " " + r[2] + " " + r[3] + " " + r[4];
           string groupName = (string)r[5];
           values.Add(new Tuple<string,string>(groupName, text));
    	}
    }
    
    //Group the values per RadioButton GroupName
    rptDummy.DataSource = values.GroupBy(x => x.Item1);
    rptDummy.DataBind();
	
