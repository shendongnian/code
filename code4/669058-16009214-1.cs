    var comments = new List<Comment>(4);
    for(int i = 1 ; i < 5 ; i++) {
        comments.Add(new Comment {
             CreatedOn = DateTime.Now.AddMinutes(i), IndexNo = i });
    }
