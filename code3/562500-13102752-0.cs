	var collection = new List<dynamic>();
	foreach (ListItem cBox in chkGodownlst.Items)
	{
	   if(cBox.Selected)
	   {
		   collection.AddRange(dt.AsEnumerable().Where(r => r.Field<int>("CountryID") == Convert.ToInt32(cBox.Value)));
	   }
	}
	GridView1.DataSource = collection;
	GridView1.DataBind();
