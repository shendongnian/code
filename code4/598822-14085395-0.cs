    var query = from to in allCurrentTradeObjects
                from ro in theseWantMe
                where ro.Type == to.Type &&
                      ro.MaxRent >= to.Rent &&
                      ro.MinRooms <= to.Rooms &&
                      ro.MinSquareMeters <= to.SquareMeters &&
                      ro.MaxPrice >= to.Price &&
                      ro.MinFloors <= to.Floors &&
                      ro.TradeObjectId != to.TradeObjectId &&
                      ro.TradeObjectId != myTradeObject.TradeObjectId
                select new RatingListTriangleModel
                {
                    To1Id = myTradeObject.TradeObjectId,
                    To2Id = to.TradeObjectId,
                    To3Id = ro.TradeObjectId,
                    T1OnT2Rating = 0,
                    T2OnT3Rating = 0,
                    T3OnT1Rating = 0,
                    TotalRating = 0
                };
        
    foreach(var rlt in query)
       this.InsertOrUpdate(rlt);
        
    this.Save(); 
