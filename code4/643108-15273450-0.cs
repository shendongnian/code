    var query = from c in context.FavoriteColor
                select new { c.Id, c.ColorIndex };
    var result = from c in query.ToList()
                 select new Item
                 {
                     Id = c.Id,
                     ColorName = Colors.Names.Where(x => x.Index == c.ColorIndex).FirstOrDefault().Name
                 };
