    IEnumerable<RatingAndProducts> ratingsToPick = context.RatingAndProducts
        .OrderByDescending(c => c.WeightedRating);
    
    if (!takeAll)
        ratingsToPick = ratingsToPick.Take(pAmmount);
    var results = ratingsToPick.ToList();
