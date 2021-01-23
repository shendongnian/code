    string[] tagNames = new string[2]{ "Admins", "Users" };
    using (NHibernate.ISession session = SessionFactory.GetCurrentSession())
    {
        IList<Blog> blogsFound = session.QueryOver<Blog>()
                                        .Right.JoinQueryOver<Tags>(x => x.Tags)
                                        .WhereRestrictionOn(x => x.Name).IsIn(tagNames)
                                        .List<Blog>();
    }
