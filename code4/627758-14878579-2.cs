    var user = userRepository.GetById(someExistingUserId);
    
    var post = new Post
    {
       Title = "Example title",
       Summary = "Example summary",
       Added = DateTime.Now,
       OwnerInfo = new PostOwnerInfo
       {
            UserId = user.Id,
            Name = user.Name
       }
    };
    postRepository.Update(post);
