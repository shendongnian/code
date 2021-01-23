    using (var context = new ctxEntities())
    {
        context.MyTable.MergeOption = MergeOption.NoTracking;
        var result = context.MyTable.Include("LinkedTable")
                           .Where(c => c.RepairID == repairID).ToList();
        return result;
    }
