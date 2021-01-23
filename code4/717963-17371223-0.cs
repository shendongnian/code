    var sql = 
    @"select * from #Posts p 
    left join #Users u on u.Id = p.OwnerId 
    Order by p.Id";
    
    var data = connection.Query<Post, User, Post>(sql, (post, user) => { post.Owner = user; return post;});
    var post = data.First();
    
    post.Content.IsEqualTo("Sams Post1");
    post.Id.IsEqualTo(1);
    post.Owner.Name.IsEqualTo("Sam");
    post.Owner.Id.IsEqualTo(99);
