    public static class ValidityExtensions
    {
        public static IQueryable<T> Valid<T>(this IQueryable<T> validities, DateTime time) where T : Validity
        {
            return validities.Where(v => (v.ValidFrom == null || ValidFrom >= time) && (v.ValidTo == null || v.ValidTo < time));
        }
    }
