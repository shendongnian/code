    public interface IFilter
    {
        public Func<Program,bool> Matches { get; }
    }
        public static int CountByFilter(this IEnumerable<P> ProgramList, IEnumerable<IFilter> filters)
        {
            return (from p in ProgramList
                    where filters.Any(f => f.Matches(p))  //or All
                    select p).Count();
        }
