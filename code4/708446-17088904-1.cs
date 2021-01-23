    var query = from c in db.something
                where c.othersomething == "onlyyouknow"
                orderby c.othersomething
                select new { NewObject = c.othersomething };
    
    DataTable MyDataTable = new DataTable();
    myDataTable.Columns.Add(
        new DataColumn()
        {
            DataType = System.Type.GetType("System.String"),//or other type
            ColumnName = "Name"      //or other column name
        }
    );
    
    foreach (var element in query)
    {
        var row = MyDataTable.NewRow();
        row["Name"] = element.NewObject;
        myDataTable.Rows.Add(row);
    }
