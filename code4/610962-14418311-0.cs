    var result =
            from priceLog in PriceLogList
            group priceLog by priceLog.LogDateTime.ToString("MMM yyyy") into dateGroup
            select new {
                LogDateTime = dateGroup.Key,
                AvgPrice = dateGroup.Average(priceLog => priceLog.Price)
            };
