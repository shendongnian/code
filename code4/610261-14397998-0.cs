    var posts = MVPMetroEntities.Posts
                    .Select(p => new { 
                         Date = p.Comments.Any() 
                                    ? p.Comments.OrderByDescending(c => c.DateCommented).First().Date 
                                    : p.DatePosted, 
                         Post = p
                      }
                    .OrderByDescending(x => x.Date);
