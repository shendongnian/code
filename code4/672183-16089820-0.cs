    public static class Extensions
    {
        public static IQueryable<InventoryItem> WhereIsLastState(
            this IQueryable<InventoryItem> query, Type state)
        {
            if (state == typeof(InactiveState))
                return query.Where(i => i.LastState is InactiveState);
            if (state == typeof(ActiveState))
                return query.Where(i => i.LastState is ActiveState);
            if (state == typeof(CompletedState))
                return query.Where(i => i.LastState is CompletedState);
            throw new InvalidOperationException("Unsupported type...");
        }
    }
