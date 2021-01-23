    var partialQuery = (from ts in context.TradeSnapshots
                            group ts by ts.DaysInTrade
                            into gts
                            select
                            new
                                {
                                    profit = gts.Sum(s => s.PercentGain),
                                    DIT = gts.Key
                                });
    dataGridViewTradeSnapshots.DataSource = partialQuery.ToList();
