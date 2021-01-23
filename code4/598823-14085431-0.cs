    allCurrentTradeObjects.Select (
                to => to.theseWantMe.Where ( ro => !(ro.Type != to.Type 
                    || ro.MaxRent < to.Rent
                    || ro.MinRooms > to.Rooms
                    || ro.MinSquareMeters > to.SquareMeters
                    || ro.MaxPrice < to.Price
                    || ro.MinFloors > to.Floors
                    || ro.TradeObjectId == to.TradeObjectId
                    || ro.TradeObjectId == myTradeObject.TradeObjectId))
                   .Select({
                                 var rlt =  new RatingListTriangleModel
                                  {
                                     To1Id = myTradeObject.TradeObjectId,
                                     To2Id = to.TradeObjectId,
                                     To3Id = ro.TradeObjectId,
                                     T1OnT2Rating = 0,
                                     T2OnT3Rating = 0,
                                     T3OnT1Rating = 0,
                                    TotalRating = 0
                                };
                               this.InsertOrUpdate(rlt);
                               return rlt;
                             } ).ToArray();
     this.Save();
