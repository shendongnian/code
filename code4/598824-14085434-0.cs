     var rtls = allCurrentTradeObjects
         .SelectMany(to => theseWantMe.Select(ro => new {to, ro}));
         .Where(p => p.ro.Type == p.to.Typpe && p.ro.MaxRent >= p.to.Rent && ...)
        .Select(p => new RatingListTriangleModel {
            To1Id = myTradeObject.TradeObjectId,
            To2Id = p.to.TradeObjectId,
            To3Id = p.ro.TradeObjectId,
            ...
        });
