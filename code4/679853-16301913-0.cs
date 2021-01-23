    DBSet<User> users;
    string cat = "myCategory";
    var usersByCategoryActivity = users
                 .OrderByDescending(u => u.Activities
                                .Where(a => a.Categories.Select(c => c.Name)
                                                        .Contains(cat)
                                .Count()
                         );
