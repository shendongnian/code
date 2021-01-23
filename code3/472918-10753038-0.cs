        public Expression<Func<TModel, IEnumerable>> ConvertExpression<TModel, TItem>(Expression<Func<TModel, IList<TItem>>> expression)
        {
            return (Expression<Func<TModel, IEnumerable>>)Expression
                .Lambda(Expression.Convert(expression.Body, typeof(IEnumerable)), expression.Parameters);
        }
