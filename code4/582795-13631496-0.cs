    lock(CicApplication.DistributorBackpressure44Cache)
    {
        var sequence = from row in CicApplication.DistributorBackpressure44Cache
                       where row.Coater == this.Coater && row.IsDistributorInUse
                       select new GenericValue
                       {
                           ReadTime = row.CoaterTime.Value,
                           Value = row.BackpressureLeft
                       };
    }
    this.EvaluateBackpressure(sequence, "BackpressureLeftTarget");
