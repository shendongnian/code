    DataTable DataTable1 = new DataTable();
    DataTable DataTable2 = new DataTable();
     
    DataTable1.Columns.Add("ID");
    DataTable1.Columns.Add("ColA");
    DataTable1.Rows.Add(1, "A");
    DataTable1.Rows.Add(2, "B");    
     
    DataTable2.Columns.Add("ID");
    DataTable2.Columns.Add("ColB");
    DataTable2.Rows.Add(1, "B");
 
    var result = from x in DataTable1.AsEnumerable()
                 join y in DataTable2.AsEnumerable() on x["ID"] equals y["ID"] into DataGroup                         
                 from item in DataGroup.DefaultIfEmpty()
                 select new {
                                ID = x["ID"],
                                ColA = x["ColA"],
                                ColB = item == null ? string.Empty : item["ColB"]
                            };
    foreach (var s in result)
        Console.WriteLine("{0}", s);
