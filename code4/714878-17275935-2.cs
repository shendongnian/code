    class SameStringTuplesComparer: EqualityComparer<Tuple<string, string>> 
    {
       public override bool Equals(Tuple<string, string> t1, Tuple<string, string> t2)
       {
          return t1.Item1.Equals(t2.Item1, StringComparison.CurrentCultureIgnoreCase) && t1.Item2.Equals(t2.Item2, StringComparison.CurrentCultureIgnoreCase)
       }
       public override int GetHashCode(Tuple<string, string> t)
       {
         return base.GetHashCode();
       }
    }
