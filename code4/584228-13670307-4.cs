    public Class Result{
      public string a {get;set}
      public string b {get;set}
      public string c {get;set}
      public string d {get;set}
      //this is a short incomplete version of equals implementation
      //consult other questions to learn more about equality
      public override boolean Equals(Result other)
      { return other.a == a && other.b == b && other.c == c && other.d == d}
    }
    //you must add another order by clause to query so that both of them have the same order
    var sets =
         (from a in patient.AsParallel()
         from b in patient.AsParallel()
         from c in patient.AsParallel()
         from d in patient.AsParallel()
         where a.VisitNum < b.VisitNum && b.VisitNum < c.VisitNum && c.VisitNum < d.VisitNum
         select new Result{ a = a, b = b, c = c, d = d }).AsEnumerable();
    var sets1 =
         (from a in patient1.AsParallel()
         from b in patient1.AsParallel()
         from c in patient1.AsParallel()
         from d in patient1.AsParallel()
         select new Result{ a = a, b = b, c = c, d = d }).AsEnumerable();
    //Now it would be right
    if (Enumerable.SequenceEqual(sets, sets1))
    {
       //do your stuff
    }
