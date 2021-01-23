    public T UpdatePost(DateTime DateUpdated, DateTime DateExpires, object Id)
    {
        using (var session=sessionFactory.OpenSession())
        {
            using (var transaction=session.BeginTransaction())
            {
                T post = session.Get<T>(Id);
                post.DateUpdated = DateUpdated;
                post.DateExpires = DateExpires;
                session.Update(post);
                transaction.Commit();
                return post;
            }
        }
    }
