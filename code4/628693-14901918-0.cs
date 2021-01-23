    public void DeletePostForUser(int id, int userId)
    {
        var post = context.Posts.SingleOrDefault(m => m.PostId == id && m.User.UserId == userId)
        if (post != null)
        {
            context.Posts.Remove(post);
            context.SaveChanges();
        }
    }
