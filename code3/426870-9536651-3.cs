    public class Row
    {
       public int GroupA { get; set; }
       public int GroupB { get; set; }
       public int Element { get; set; }
       public int ElementOrder { get; set; }
    }
    private IEnumerable<int> ReturnLogicalGroupingAForOrderedElements(IList<int> elements)
    {
        Expression parameter = Expression.Parameter(typeof(Row), "x");
        Expression propElement = Expression.Property(parameter, "Element");
        Expression propElementOrder = Expression.Property(parameter, "ElementOrder");
        Expression where;
        for (int i = 0; i < elements.Count; i++)
        {
            var restriction = Expression.AndAlso(
                Expression.Equal(propElement, elements[i]),
                Expression.Equal(propElementOrder, i + 1));
            
            if (where == null)
                where = restriction;
            else
                where = Expression.Or(where, restriction);
        }
        var groupsWithSameOrder = Rows.Where(where)
            .GroupBy(r => new { r.GroupA, r.GroupB })
            .Where(g => g.Count() == elements.Count)
            .Select(g => g.Key);
        return groupsWithSameOrder.Except(Rows
                .Where(r => groupsWithSameOrder.Contains(new { r.GroupA, r.GroupB }))
                .GroupBy(r => new { r.GroupA, r.GroupB })
                .Where(g => g.Count() != elements.Count)
                .Select(g => g.Key))
            .Select(key => key.GroupA);
    }
