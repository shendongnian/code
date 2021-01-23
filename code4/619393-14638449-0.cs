    var posts = db.Posts.Where(a => a.Privacy == "public")
                        .OrderByDescending(a => a.PostedTime)
                        .Select(a=> new { Post = a, User = a.Poster });
    foreach (var post in posts) { 
        People.Add(post.User.Id);
    }
