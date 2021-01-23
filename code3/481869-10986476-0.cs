    List<RestaurantRecord> _Restaurants;
    
    public RestaurantRecord Best()
    {
        return _Restaurants.Where(
                   x =>
                       x.AverageRating >= _BestRating &&
                       x.ReviewCount >= _MinReviews &&
                       x.Distance <= _MaxDistance)
                           .GetFirstOrDefault();
    }
