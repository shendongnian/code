    RoadTaxDto tmp;
    foreach (var g in list.GroupBy(i => i.GetHashCode()))
    {
        if ((tmp = g.FirstOrDefault(i => i.ItemDesc != "None")) != null)
            list2.Add(tmp);
        else
            list2.Add(g.First());
    }
