    List<int> Depts = new List<int>() {1, 3};
    var result = Categories.Where(d => Depts.Contains(d.DeptId))
                           .GroupBy(g => new {g.CatId, g.Name})
                           .Where(g => g.Count() >= 2)
                           .Select(g => new {g.Key.CatId, g.Key.Name});
