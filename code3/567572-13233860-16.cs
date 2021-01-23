    public static IQueryable<YourType> FilterByStatus(this IQueryable<YourType> query, 
                                                      string status)
    {
    
        switch (status) {
           case "0":
                return query.Where(x => x.status < 0);            
           case "-1":
                return query.Where(x => x.status == -1);
           case "-100":
                return query.Where(x => x.status == -100);
           case "1":
           default:
                return query.Where(x => x.status >= 0);
        }
    }
