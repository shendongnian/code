    IEnumerable<IEnumerable<Consignment>>
    Partitioner(ConsignmentGroupKey key, IEnumerable<Consignment> cg)
    {
        cg = cg.OrderBy(c => c.DeliverFrom);
        var startTime = cg.First().DeliverFrom;
        var subgroup = new List<Consignment>();
        foreach(var cons in cg) {
            if ((cons.DeliverFrom - startTime).TotalMinutes < 60) {
                subgroup.Add(cons);
            }
            else {
                yield return subgroup;
                startTime = cons.DeliverFrom;
                subgroup = new List<Consignment>() { cons };
            }
        }
        if (subgroup.Count > 0) {
            yield return subgroup;
        }
    }
