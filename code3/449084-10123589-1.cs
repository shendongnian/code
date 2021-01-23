    List<dynamic> list = new List<dynamic>();
    list.Add(new { Col1 = "AB", Col2 = 23 });
    list.Add(new { Col1 = "CD", Col2 = 23 });
    list.Add(new { Col1 = "AB", Col2 = 5 });
    list.Add(new { Col1 = "EF", Col2 = 9 });
    
    string[] columns = new string[] { "Col1", "Col2" };
    foreach (string column in columns)
    {
        var elems = list.Select(d => ObjectUtils.GetPropertyByName(d, column)).Distinct().ToList();
        // elems will be "AB", "CD", "EF" for Col1
        //           and 23, 5, 9 for Col2
    }
