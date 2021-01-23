    var Posts = (from cu in ListCorpUsers
                 join p in ListPosts on cu.UserName equals p.UserName
                 select new {
                     FriendlyName = cu.FriendlyName,
                     UserName = cu.UserName,
                     Content = p.Content
                 }).ToList();
