    //get column 1 data to a list from dataset1
    var list1 = ds1.Tables[0].AsEnumerable().Select(x => x[0].ToString());
    //get column 1 data to a list from dataset2
    var list2 = ds2.Tables[0].AsEnumerable().Select(x => x[0].ToString());
    //merge two list items 
    var mergedList = list1.Zip(list2, (a, b) => a + " ," + b);
    // create new datatable 
    DataTable dt = new DataTable();
    dt.Columns.Add("ColumnName", typeof(string)); // give proper column name
    foreach (string item in mergedList)
    {
        dt.Rows.Add(item); // add each item as row 
    }
    DataSet ds3 = new DataSet(); 
    // add newly created table to dataset 3
    ds3.Tables.Add(dt);
