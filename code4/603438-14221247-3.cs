    public static class Extensions
    {
        public static Boolean IsActive(this IHaveAActivityPeriod item)
        {
            var now = DateTime.Now;
            return item.active &&
                   (item.publishStart <= now)
                   (!item.publishEnd.HasValue || (item.publishEnd > now));
        }
    }
