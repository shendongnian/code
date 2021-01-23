    public RestaurantRecord Best()
    {
        IQueryable temp = _Restaurants.Clone();
        temp = temp.Where( x => x.AverageRating >= _BestRating );
        temp = temp.Where( x => x.ReviewCount >= _MinReviews );
        // ...snip...
        return temp.GetFirstOrDefault();
    }
