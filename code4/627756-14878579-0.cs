    var user = userRepository.GetById(someExistingUserId);
    
    var post = new Post
    {
       Title = "Example title",
       Summary = "Example summary",
       Added = DateTime.Now,
       Owner = user
    };
    postRepository.Update(post);
