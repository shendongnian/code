    var result = assembledPcb.AssembledParts.GroupBy(entry => new
    {
        entry.PID,
        entry.Posiotion.Station,
        entry.Posiotion.Slot,
        entry.Posiotion.Subslot,
        entry.Partnumber,
        entry.ReelID,
        entry.BlockId
    })
    .Select(g => new AssembledPartsDTO
    {
        BlockId = g.Key.Key.BlockId,
        PID = g.Key.PID,
        Partnumber = g.Key.Partnumber,
        ReelID = g.Key.ReelID,
        Posiotion = new McPosition(g.Key.Station, g.Key.Slot, g.Key.Subslot),
        References = g.SelectMany(entry => entry.References)
                      .Distinct()
                      .ToList()
    });
