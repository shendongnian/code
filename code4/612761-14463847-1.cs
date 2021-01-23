    var dateRanges = new List<ReplicationDateRange>();
    DateTime baselineDate = DateTime.MinValue;
    ReplicationDateRange currentDateRange = null;
    foreach (var block in lf.ReplicationBlocks.OrderBy(x => x.InitiationDate))
    {
        if ((block.InitiationDate - baselineDate).TotalMinutes <= 5)
        {
            currentDateRange.EndDate = block.InitiationDate;
            currentDateRange.EndId = block.ReplicateId;
        }
        else
        {
            baselineDate = block.InitiationDate;
            currentDateRange = new ReplicationDateRange()
            {
                StartDate = block.InitiationDate,
                EndDate = block.InitiationDate,
                StartId = block.ReplicateId,
                EndId = block.ReplicateId
            };
            dateRanges.Add(currentDateRange);
        }
    }
    foreach (var d in dateRanges)
    {
        Console.WriteLine(d);
    }
