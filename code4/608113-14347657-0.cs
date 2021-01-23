    IEnumerable<int> t1 = new List<int> { 1, 2, 3 };
    IEnumerable<int> t2 = new List<int> { 1, 2, 3 };
    var t12 = t1.Zip(t2, (outer, inner) => new { Outer = outer, Inner = inner });
    var t3 = t12.Select(t => new { O = t.GetPropValue("Outer"), 
                                   I = t.GetPropValue("Inner") });
