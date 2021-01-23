    public IEnumerable<UserReadNews> GetLatestUserReadNews(IEnumerable<string> userIds)
    {
        IQuery query = Session.CreateQuery("from UserReadNews as j where j.FacebookUser_id in (:userIds)");
        query.SetParameterList("userIds", userIds );
        return query.Future<UserReadNews>();
    }
