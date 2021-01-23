    // ...
    Dictionary<string, string> _mapping = new Dictionay<string, string>();
    _mappaing.Add("columnA", "propertyA");
    // and so on
    // ...
    try
    {
        foreach (DataRow dr in dt.Rows)
        {
            BsonDocument bson = new BsonDocument();
    
            for (int i = 0; i < dr.ItemArray.Count(); i++)
            {
                // here use the mapped name instead of the colmn name
                bson.Add(_mapping[dr.Table.Columns[i].ColumnName], dr[i].ToString());
            }
            collection.Insert(bson);
        }
    }
