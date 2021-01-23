        var list = new List<Model>();
        list.Add(new Model { Date = DateTime.Now, Total = 3 });
        list.Add(new Model { Date = DateTime.Now, Total = 3 });
        list.Add(new Model { Date = DateTime.Now, Total = 3 });
        var combined = from item in list
                       group item by new { item.Date, item.Total }
                       into grouped
                       select new Model
                           {
                               Date = grouped.Key.Date,
                               Total = grouped.Sum(i => i.Total)
                           };
