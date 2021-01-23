        public static class LinqExtensions
    {
        public static IQueryable<T> WhereLike<T>(this IQueryable<T> source, String Name, String value)
        {
            Type model = typeof(T);
            ParameterExpression param = Expression.Parameter(typeof(T), "m");
            PropertyInfo key = model.GetProperty(Name);
            MemberExpression lhs = Expression.MakeMemberAccess(param, key);
            Expression<Func<T, String>> lambda = Expression.Lambda<Func<T, String>>(lhs, param);
            return source.Where(BuildLikeExpression(lambda, value));
        }
        public static IQueryable<T> WhereLike<T>(this IQueryable<T> source, Expression<Func<T, String>> valueSelector, String value)
        {
            return source.Where(BuildLikeExpression(valueSelector, value));
        }
        public static Expression<Func<T, Boolean>> BuildLikeExpression<T>(Expression<Func<T, String>> valueSelector, String value)
        {
            if (valueSelector == null)
                throw new ArgumentNullException("valueSelector");
            value = value.Replace("*", "%");        // this allows us to use '%' or '*' for our wildcard
            if (value.Trim('%').Contains("%"))
            {
                Expression myBody = null;
                ParsedLike myParse = Parse(value);
                Type stringType = typeof(String);
                if(myParse.startwith!= null)
                {
                    myBody = Expression.Call(valueSelector.Body, stringType.GetMethod("StartsWith", new Type[] { stringType }), Expression.Constant(myParse.startwith));
                }
                foreach (String contains in myParse.contains)
                {
                    if (myBody == null)
                    {
                        myBody = Expression.Call(valueSelector.Body, stringType.GetMethod("Contains", new Type[] { stringType }), Expression.Constant(contains));
                    }
                    else
                    {
                        Expression myInner = Expression.Call(valueSelector.Body, stringType.GetMethod("Contains", new Type[] { stringType }), Expression.Constant(contains));
                        myBody = Expression.And(myBody, myInner);
                    }
                }
                if (myParse.endwith != null)
                {
                    if (myBody == null)
                    {
                        myBody = Expression.Call(valueSelector.Body, stringType.GetMethod("EndsWith", new Type[] { stringType }), Expression.Constant(myParse.endwith));
                    }
                    else
                    {
                        Expression myInner = Expression.Call(valueSelector.Body, stringType.GetMethod("EndsWith", new Type[] { stringType }), Expression.Constant(myParse.endwith));
                        myBody = Expression.And(myBody, myInner);
                    }
                }
                return Expression.Lambda<Func<T, Boolean>>(myBody, valueSelector.Parameters.Single());
            }
            else
            {
                Expression myBody = Expression.Call(valueSelector.Body, GetLikeMethod(value), Expression.Constant(value.Trim('%')));
                return Expression.Lambda<Func<T, Boolean>>(myBody, valueSelector.Parameters.Single());
            }
        }
        private static MethodInfo GetLikeMethod(String value)
        {
            Type stringType = typeof(String);
            if (value.EndsWith("%") && value.StartsWith("%"))
            {
                return stringType.GetMethod("Contains", new Type[] { stringType });
            }
            else if (value.EndsWith("%"))
            {
                return stringType.GetMethod("StartsWith", new Type[] { stringType });
            }
            else
            {
                return stringType.GetMethod("EndsWith", new Type[] { stringType });
            }
        }
        private class ParsedLike
        {
            public String startwith { get; set; }
            public String endwith { get; set; }
            public String[] contains { get; set; }
        }
        private static ParsedLike Parse(String inValue)
        {
            ParsedLike myParse = new ParsedLike();
            String work = inValue;
            Int32 loc;
            if (!work.StartsWith("%"))
            {
                work = work.TrimStart('%');
                loc = work.IndexOf("%");
                myParse.startwith = work.Substring(0, loc);
                work = work.Substring(loc + 1);
            }
            if (!work.EndsWith("%"))
            {
                loc = work.LastIndexOf('%');
                myParse.endwith = work.Substring(loc + 1);
                if (loc == -1)
                    work = String.Empty;
                else
                    work = work.Substring(0, loc);
            }
            myParse.contains = work.Split(new[] { '%' }, StringSplitOptions.RemoveEmptyEntries);
            return myParse;
        }
    }
