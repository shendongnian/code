    IEnumerable<IEnumerable<Consignment>>
    Partitioner(ConsignmentGroupKey key, IEnumerable<Consignment> cg)
    {
        cg = cg.OrderBy(c => c.DeliverFrom);
        var startTime = DateTime.MinValue;
        var subgroup = new List<Consignment>();
        foreach(var cons in cg) {
            if (startTime == DateTime.MinValue) {
                startTime = cons.DeliverFrom;
            }
            if ((cons.DeliverFrom - startTime).TotalMinutes < 60) {
                subgroup.Add(cons);
            }
            else {
                yield return subgroup;
                startTime = DateTime.MinValue;
                subgroup = new List<Consignment>();
            }
        }
        if (subgroup.Count > 0) {
            yield return subgroup;
        }
    }
