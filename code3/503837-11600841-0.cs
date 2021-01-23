    using (var context = new ChatContext())
    {
        pobjPost.PostTopics = new List<Topic>();
        foreach (var pobjTopic in pobjTopics)
        {
            context.Topics.Attach(pobjTopic); // topic is in state Unchanged now
            pobjPost.PostTopics.Add(pobjTopic);
        }
        context.Posts.Add(pobjPost); // post in state Added, topics still Unchanged
        context.SaveChanges();
    }
