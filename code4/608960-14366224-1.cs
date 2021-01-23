    var reviews = from r in context.Reviews.Where(r => r.CreateDate > dateFrom && r.CreateDate < dateTo)
        group r by new { r.Review1, r.User } into g
        select new UserMan
             {
               ID = g.Key.User.UserID,
               Avatar = g.Key.User.Avatar,
               LastName = g.Key.User.LastName,
               FirstName = g.Key.User.FirstName,
               Review = g.Key.Review1,
               Reviews = g.Count()
             };
    return reviews.ToList();
