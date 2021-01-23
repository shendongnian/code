    private RatingListTriangleModel CreateModel(TradeObject to, SomeOtherObject ro, int TradeObjectId)
    {
      return new RatingListTriangleModel
        {
            To1Id = myTradeObject.TradeObjectId,
            To2Id = to.TradeObjectId,
            To3Id = ro.TradeObjectId,
            T1OnT2Rating = 0,
            T2OnT3Rating = 0,
            T3OnT1Rating = 0,
            TotalRating = 0
        };
   
