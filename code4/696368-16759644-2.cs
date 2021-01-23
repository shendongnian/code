    var test = new ObservableCollection<Test>();
    foreach(var row in TestTable.Rows)
    {
        var obj = new Test()
        {
            id_test = (int)row["id_test"],
            name = (string)row["name"]
        };
        test.Add(obj);
    }
