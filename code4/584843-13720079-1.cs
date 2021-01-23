    var dt = new DataTable();
    dt.Columns.AddRange(new[] {
        new DataColumn("Parent"),
        new DataColumn("UserId"),
        new DataColumn("Child"),
        new DataColumn("Reporting_To_UserId"),
        new DataColumn("Depth"),
        new DataColumn("id")
    });
    dt.Rows.Add(new object[] { "", 0, "Aditya", 13, 0, 12 });
    dt.Rows.Add(new object[] {"Aditya", 13, "Abhishek", 4, 0, 13});
    dt.Rows.Add(new object[] { "Abhishek", 4, "Saurabh", 6, 1, 16 });
    dt.Rows.Add(new object[] { "Abhishek", 13, "Mohinder", 8, 1, 17 });
    dt.Rows.Add(new object[] { "Mohinder", 8, "Mohammad", 14, 2, 18 });
    dt.Rows.Add(new object[] { "Saurabh", 6, "Rahul", 1, 2, 11 });
    dt.Rows.Add(new object[] { "Saurabh", 6, "Amitesh", 5, 2, 12 });
    var result = BuildXML("", dt);
