                DataTable dt1 = new DataTable();
                dt1.Columns.AddRange(new DataColumn[] { 
                new DataColumn("ID1") });
    
                for (int i = 0; i < 10; i++)
                    dt1.Rows.Add(i + 1);
    
                DataTable dt2 = new DataTable();
                dt2.Columns.AddRange(new DataColumn[] { 
                new DataColumn("ID2") });
    
                for (int i = 0; i < 5; i++)
                    dt2.Rows.Add(i + 1);
    
                var queryOne = from row in dt1.AsEnumerable()
                               from row1 in dt2.AsEnumerable()
                               select new
                               {
                                   id1 = row.Field<string>("ID1"),
                                   id2 = row1.Field<string>("ID2")
                               };
    
                var result = queryOne.ToList();
