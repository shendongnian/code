    var myTradeObject = GetThatOneObject();
    
    IEnumerable<RatingListTriangleModel> query =
      from to in allCurrentTradeObjects
     //pre-emptively filter to the interesting objects in the first collection
      where to.TradeObjectId == myTradeObject.TradeObjectId
     //take advantage of hashing in Enumerable.Join - theseWantMe is enumerated once
      join ro in theseWantMe
        on new {to.Type, to.TradeObjectId}
        equals new {ro.Type, ro.TradeObjectId}
     //remaining matching criteria
      where to.Rent <= ro.MaxRent   //rent is lower than max
        && ro.MinRooms <= to.Rooms   //rooms are higher than min
        && ro.MinSquareMeters <= to.SquareMeters  //area is higher than min
        && to.Price <= ro.MaxPrice     //price is lower than max
        && ro.MinFloors <= to.Floors   // floors are higher than min
      select CreateRatingListTriangleModel(myTradeObject, to, ro);
    
    foreach(RatingListTriangleModel row in query)
    {
      this.InsertOrUpdate(row);
    }
    this.Save();
