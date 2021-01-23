    public static class Predicates
    {
        public static Expression<Func<User, bool>> CheckForFlags()
        {
            return (user => user.Flag1 || user.Flag2 || user.Flag3 ||
                            user.Flag4 || user.Flag5);
        }
        public static Expression<Func<User, bool>> CheckForCriteria(string value)
        {
            return (user => user.Criteria1 == value);
        }
    }
