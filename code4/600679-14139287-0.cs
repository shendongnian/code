    DataTable city = new DataTable(); // instantiate here
    for (int i = 0; i < gridview1.Rows.Count; i++)
    {
        // your code here
        foreach(var singleItem in objyojnadetail4.Selectcity().Rows)
        {
            city.Rows.Add(singleItem);
        }
    }
