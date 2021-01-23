    public class SomeClass
    {
        public DateTime RatingDate;
        public string RatingType;
        public int Rating;
    }
    var data = new SomeClass[]
    {
        new SomeClass() { RatingDate = DateTime.Parse("6/7/2012"), RatingType = "Type1", Rating = 1 },
        new SomeClass() { RatingDate = DateTime.Parse("6/7/2012"), RatingType = "Type2", Rating = 3 },
        new SomeClass() { RatingDate = DateTime.Parse("6/7/2012"), RatingType = "Type3", Rating = 5 },
        new SomeClass() { RatingDate = DateTime.Parse("8/7/2012"), RatingType = "Type1", Rating = 5 },
        new SomeClass() { RatingDate = DateTime.Parse("8/7/2012"), RatingType = "Type2", Rating = 2 },
        new SomeClass() { RatingDate = DateTime.Parse("8/7/2012"), RatingType = "Type3", Rating = 4 },
        new SomeClass() { RatingDate = DateTime.Parse("8/7/2012"), RatingType = "Type4", Rating = 1 }
    };
    var ratingTypes = data.Select(i => i.RatingType)
        .Distinct().OrderBy(i => i).ToArray();
    var results = data.GroupBy(i => i.RatingDate)
        .Select(g => new { RatingDate = g.Key, Ratings = ratingTypes.GroupJoin(g, o => o, i => i.RatingType, (o, i) => i.Select(x => x.Rating).Sum()).ToArray() })
        .ToArray();
