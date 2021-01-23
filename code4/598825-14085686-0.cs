    private bool IsMatchingTradeObject (TradeObject to, SomeOtherObject ro, int TradeObjectId)
    {
      return ro.Type == to.Type &&
                      ro.MaxRent >= to.Rent &&
                      ro.MinRooms <= to.Rooms &&
                      ro.MinSquareMeters <= to.SquareMeters &&
                      ro.MaxPrice >= to.Price &&
                      ro.MinFloors <= to.Floors &&
                      ro.TradeObjectId != to.TradeObjectId &&
                      ro.TradeObjectId != TradeObjectId;
    }
