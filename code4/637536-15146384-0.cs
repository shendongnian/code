    class ExpressionHolder
    {
        public int Value { get; set; }
        public Expression<Func<Brand, bool>> Expr { get; private set; }
        public ExpressionHolder()
        {
            Expr = MakeWhereForPK();
        }
        private Expression<Func<Brand, bool>> MakeWhereForPK()
        {
            var paramExp = Expression.Parameter(typeof(Brand), "b");
            var leftExp = Expression.Property(paramExp, "ID");
            var rightExp = Expression.Property(Expression.Constant(this), "Value");
            var whereExp = Expression.Equal(leftExp, rightExp);
            return Expression.Lambda<Func<Brand, bool>>(whereExp, paramExp);
        }
    }
