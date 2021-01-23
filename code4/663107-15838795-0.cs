    var tradeReqsBySegment = segGroups.Join(pPeriods, s => s.MarketSegmentId, p => p.EntityId, (s, p) => new
    {
        SegmentCode = s.SegmentCode, // string
        Time = p.StartLocal, // datetime
        TradeRequirement = p.Volume // double
    })
    .GroupBy(s => s.SegmentCode)
    .ToDictionary(g => g.Key,
                  g => g.GroupBy(gr => new DateTime(gr.Time.Year, gr.Time.Month, 1))
                        .ToDictionary(gr => gr.Key.ToString("MM/yyyy"),
                                      gr => new {
                                          Sum = gr.Sum(s => s.TradeRequirement),
                                          Avg = gr.Average(s => s.TradeRequirement)
                                      }));
