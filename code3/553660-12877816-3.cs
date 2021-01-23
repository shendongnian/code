    Store.A.SetValue(42);
    Store.A.SetValue("Douglas Adams");
    Store.A.SetValue(new DirectoryInfo(@"C:\"));
    Store.A.SetValue(new List<int>());
    var x1 = Store.A.GetValue<int>();           // --> 42
    var x2 = Store.A.GetValue<string>();        // --> "Douglas Adams"
    var x3 = Store.A.GetValue<DirectoryInfo>(); // --> DirectoryInfo{ C:\ }
    var x4 = Store.A.GetValue<List<int>>();     // --> List<int>{ Count = 0 }
