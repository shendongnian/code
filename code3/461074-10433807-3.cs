    var sections = new List<string>();
    if (DB.DbColumn_1.GetValueOrDefault()) sections.Add("thing 1");
    if (DB.DbColumn_2.GetValueOrDefault()) sections.Add("thing 2");
    //...other columns
    var things = string.Join(";", sections);
