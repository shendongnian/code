    public class Deck_Ratings : AbstractIndexCreationTask<DeckRating, Deck_Ratings.ReduceResult>
    {
        public class ReduceResult
        {
            public string DeckId { get; set; }
            public int TotalRating { get; set; }
            public int CountRating { get; set; }
            public double AverageRating { get; set; }
        }
        public Deck_Ratings()
        {
            Map = deckRatings => deckRatings.Select(deckRating => new 
                                 { 
                                     deckRating.DeckId,
                                     TotalRating = deckRating.Rating,
                                     CountRating = 1,
                                     AverageRating = 0
                                 });
            Reduce = reduceResults => reduceResults
                                          .GroupBy(reduceResult => reduceResult.DeckId)
                                          .Select(grouping => new 
                                                  {
                                                      DeckId = grouping.Key, 
                                                      TotalRating = grouping.Sum(reduceResult => reduceResult.TotalRating)
                                                      CountRating = grouping.Sum(reduceResult => reduceResult.CountRating)
                                                   })
                                          .Select(x => new
                                                   {
                                                      x.DeckId,
                                                      x.TotalRating,
                                                      x.CountRating,
                                                      AverageRating = x.TotalRating / x.CountRating
                                                   });
        }
    }
