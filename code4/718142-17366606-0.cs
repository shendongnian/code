      DataTable DBTable = LoadMailingListContent(Location);
        DataColumn dc = new DataColumn("FirstName");
         DBTable.Columns.Add(dc);
         dc = new DataColumn("LastName");
         DBTable.Columns.Add(dc);
         foreach (DataRow d in DBTable.Rows)
         { 
             var names = d["fullname"].ToString().Split(' ');
             d["FirstName"] = names[0];
             d["LastName"] = names[1];
         }
