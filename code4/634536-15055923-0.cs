    public static class Operators<TC>
    {
        private static Func<TC, TC, TC> _add = null;
    
        public static TM Add<TM>(TM a, TM b)
        {
            if (_add == null) {
                var param1Expr = Expression.Parameter(typeof(TM));
                var param2Expr = Expression.Parameter(typeof(TM));
                var addExpr = Expression.Add(param1Expr, param2Expr);
                var expr = Expression.Lambda<Func<TM, TM, TM>>
                              (addExpr, param1Expr, param2Expr);
                _add = expr.Compile();
            }
            return _add.Invoke(a, b);
        }
    }
