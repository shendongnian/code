    public static class Name
    {
        public static string Of(LambdaExpression selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            var mexp = selector.Body as MemberExpression;
            if (mexp == null)
            {
                var uexp = (selector.Body as UnaryExpression);
                if (uexp == null)
                    throw new TargetException(
                        "Cannot determine the name of a member using an expression because the expression provided cannot be converted to a '" +
                        typeof(UnaryExpression).Name + "'."
                    );
                mexp = uexp.Operand as MemberExpression;
            }
            if (mexp == null) throw new TargetException(
                "Cannot determine the name of a member using an expression because the expression provided cannot be converted to a '" +
                typeof(MemberExpression).Name + "'."
            );
            return mexp.Member.Name;
        }
        public static string Of<TSource>(Expression<Func<TSource, object>> selector)
        {
            return Of<TSource, object>(selector);
        }
        public static string Of<TSource, TResult>(Expression<Func<TSource, TResult>> selector)
        {
            return Of(selector as LambdaExpression);
        }
    }
    public static class NameExtensions
    {
        public static string NameOf<TSource, TResult>(this TSource obj, Expression<Func<TSource, TResult>> selector)
        {
            return Name.Of(selector);
        }
        public static string NameOf<TSource>(this TSource obj, Expression<Func<TSource, Action>> selector)
        {
            return Name.Of(selector);
        }
    }
