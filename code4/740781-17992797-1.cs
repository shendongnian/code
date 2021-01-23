    var ccsum = from a in dtSumGL2.AsEnumerable()
                group Math.Abs(a.Field<double>(SumGLColumn.PSPassBegCost)) 
                      by a.Field<string>(SumGLColumn.BaseCC) into g
                select new {
                   BaseCCg = g.Key,
                   PSPassBegCost = g.Sum()
                };
    
