     public interface Searchable
     {
          IEnumerable<ParamInfo> Params { get; }
          Func<bool> Predicate { get; }
     }
