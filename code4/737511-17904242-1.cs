    public IList<UserRating> GetUserRatings<TKey>(
        int userId, 
        IPager pager, 
        Expression<Func<UserRating, TKey>> orderBy)
    {
        return _userRatingRepository
            .Table
            .Where(a => a.UserId == userId)
            .Skip(pager.Skip)
            .Take(pager.PageSize)
            .OrderBy(orderBy)
            .ToList();
    }
