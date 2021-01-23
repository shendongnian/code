    void Main()
    {
        Expression<Func<int, bool>> pageIndexCondition = idx => idx == 1;
        Expression<Func<BookPage, bool>> converted = ExpressionConverter.Convert(pageIndexCondition);
    }
    public class ExpressionConverter : ExpressionVisitor
    {
        public static Expression<Func<BookPage, bool>> Convert(Expression<Func<int, bool>> e)
        {
            var oldParameter = e.Parameters.First();
            var newParameter = Expression.Parameter(typeof(BookPage), "bp");
            var property = typeof(BookPage).GetProperty("PageIndex");
            var memberAccess = Expression.Property(newParameter, property);
		
            var converter = new ExpressionConverter(oldParameter, memberAccess);
            return (Expression<Func<BookPage, bool>>)Expression.Lambda(converter.Visit(e.Body), newParameter);
        }
	
        private ParameterExpression pe;
        private Expression replacement;
	
        public ExpressionConverter(ParameterExpression pe, Expression replacement)
        {
            this.pe = pe;
            this.replacement = replacement;
        }
	
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if(node == pe)
                return replacement;
			
            return base.VisitParameter(node);
        }
    }
