    var results = ToCalc.AsEnumerable()
        .GroupBy(r => r.Field("trade_date"))
        .Select(grp => 
                {
                    var quantity = grp.Sum(r => r.Field("EXEC_QTY"));
                    var avg = grp.Sum(r => r.Field("EXEC_QTY") * r.Field("price")) / quantity;
                    return new { 
                                   TradeDate = grp.Key, 
                                   Quantity = quantity, 
                                   WeightedAverage = avg
                               };
                });
