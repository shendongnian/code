    //Create a list to store your new shiny sk objects
    List<MyClass> sks = new List<MyClass>();
    foreach (var match in matches)
    {
        dataTable.Rows.Add(new Group[] { match.Groups["C0"], match.Groups["C1"], match.Groups["C2"], match.Groups["C3"], match.Groups["C4"] });
        MyClass sk = new MyClass();
        sk.Category = match.Groups["C0"].ToString();
        sk.Device = match.Groups["C1"].ToString();
        sk.Data_Type = match.Groups["C2"].ToString();
        sk.Value = match.Groups["C3"].ToString();
        sk.Status = match.Groups["C4"].ToString();
        //Add the object to your list
        sks.Add(sk);
    }
