    public static class Extension
        {
            public static IQueryable<MyItem> MyQuery(this IQueryable<MyItem> items, int someId)
            {
                return items.Where(x => x.ID == someId);
            }
        }
