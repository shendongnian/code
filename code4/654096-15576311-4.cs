    private static List<Object1> MergeLists(List<Object1> list1, List<Object1> list2)
    {
        var parameterComparer = new ParameterComparer();
        var distinctParameters = list1.Select(o => o.Parameters)
            .Concat(list2.Select(o => o.Parameters))
            .Distinct(parameterComparer);
        return (from p in distinctParameters
                let o1 = list1.SingleOrDefault(o => parameterComparer.Equals(p, o.Parameters))
                let o2 = list2.SingleOrDefault(o => parameterComparer.Equals(p, o.Parameters))
                let result = o2 ?? o1
                select result).ToList();
    }
