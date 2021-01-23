        public static class Member
        {
            public static string NameFrom(Expression<Action> expr)
            {
                return expr.GetMemberName();
            }
    
            public static string NameFrom<T>(Expression<Func<T>> expr)
            {
                return expr.GetMemberName();
            }
    
            public static string NameFrom<T>(Expression<Action<T>> expr)
            {
                return expr.GetMemberName();
            }
    
            public static string NameFrom<T>(Expression<Func<T, object>> expr)
            {
                return expr.GetMemberName();
            }
        }
