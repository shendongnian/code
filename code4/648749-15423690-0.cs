    var list = new List<dynamic>();
    list.Add(new { id = Guid.Empty, description = "empty" });
    list.Add(new { id = Guid.Empty, description = "empty" });
    list.Add(new { id = Guid.NewGuid(), description = "notempty" });
    list.Add(new { id = Guid.NewGuid(), description = "notempty2" });
    list = list.Distinct().ToList(); //3 elements selected
