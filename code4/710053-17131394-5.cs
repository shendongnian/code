     public interface Searchable
     {
          IEnumerable<ParamInfo> Params { get; }
          Func<string, decimal, decimal, bool> Predicate { get; }
     }
