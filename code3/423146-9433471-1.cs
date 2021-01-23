    string data = "foo1;foo2;foo3;foo4";
    
    string[] splittedData = data.Split(';');
    
    string e1 = splittedData.GetByIndexOrDefault<string>(1);    // foo1
    string e2 = splittedData.GetByIndexOrDefault<string>(2);    // foo2
    string e3 = splittedData.GetByIndexOrDefault<string>(3);    // foo3
    string e4 = splittedData.GetByIndexOrDefault<string>(4);    // foo4
    string e5 = splittedData.GetByIndexOrDefault<string>(5);    // null
