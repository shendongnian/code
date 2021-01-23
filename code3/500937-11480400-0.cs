    IEnumerable<Interval<T>> Merge<T>(IEnumerable<Interval<T>> intervals) 
      where T : IComparable<T>
    {
        //error check parameters
        var ret = new List<Interval<T>>(intervals);
        int lastCount
        do
        {
            lastCount = ret.Count;
            ret = ret.Aggregate(new List<Interval<T>>(),
                        (agg, cur) =>
                        {
                            for (int i = 0; i < agg.Count; i++)
                            {
                                var a = agg[i];
                                if (a.Contains(cur.Start))
                                {
                                    if (a.End.CompareTo(cur.End) <= 0)
                                    {
                                        agg[i] = new Interval<T>(a.Start, cur.End);
                                    }
                                    return agg;
                                }
                                else if (a.Contains(cur.End))
                                {
                                    if (a.Start.CompareTo(cur.Start) >= 0)
                                    {
                                        agg[i] = new Interval<T>(cur.Start, a.End);
                                    }
                                    return agg;
                                }
                            }
                            agg.Add(cur);
                            return agg;
                        });
        } while (ret.Count != lastCount);
        return ret;
    }
