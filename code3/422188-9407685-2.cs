    // please see: http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx
    class PrintsEqualityComparer : IEqualityComparer<Prints>
    {
        public bool Equals(Prints x, Prints y)
        {
            return object.Equals(x, y) && object.Equals(x.value, y.value);
        }
    
        public int GetHashCode(Prints obj)
        {
            return obj.range.GetHashCode() ^ obj.value.GetHashCode();
        }
    }
    var printsEqualityComparer = new PrintsEqualityComparer();
    var query = from a in listA
            from b in listB
            let timeIntersects = a.prints.Intersect(b.prints, printsEqualityComparer)
            where timeIntersects.GroupBy(x => x.range)
                                .All(x => x.Count() > 2)
            group b by a.time into grouped
            select new
            {
                TimeInDataSetA = grouped.Key,
                TimeInDataSetB = grouped.ToArray()
            };
