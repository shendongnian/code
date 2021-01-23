    public static IQueryable<Post> SatisfiesSomeCondition(this IQueryable<Post> query, SomeObj someObj)
    {
       int id = someObj.SomeObjId;
       return query.Where(post => post.SomeObjId == id);
    }
