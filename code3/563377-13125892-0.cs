    public static IQueryable<X> LimitVisible(this IQueryable<X> items) {
        return items.Where(x => !x.Hidden && !x.Parent.Hidden);
    }
    
    public static IEnumerable<X> LimitVisible(this IEnumerable<X> items) {
        return items.Where(x => !x.Hidden && !x.Parent.Hidden);
    }
