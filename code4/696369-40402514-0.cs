    var test = new ObservableCollection<Test>();
    foreach(DataRow row in TestTable.Rows)
    {
        test.Add(new Test()
        {
            id_test = (int)row["id_test"],
            name = (string)row["name"],
         });
     }
