    private static readonly Expression<Func<X, bool>> F = x => !x.Hidden && !x.Parent.Hidden;
    private static readonly Predicate<X> CompiledF = (Predicate<X>)F.Compile();
    
    public static IEnumerable<X> LimitVisible(this IEnumerable<X> e) {
        return e.Select(CompiledF);
    }
    
    public static IQueryable<X> LimitVisible(this IQueryable<X> q) {
        return q.Select(F);
    }
