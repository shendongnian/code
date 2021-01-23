    using (var context = new ChatContext())
          {
                     // Post
                     context.Posts.Attach(pobjPost);
        
                     pobjPost.PostTopics = new List<Topic>();
                     // topics
                     foreach (var i in pobjTopics)
                     {
        
                     pobjPost.PostTopics.Add(i);
                     }
