    public class FilterConverter : IFilterConverterVisitor<Filter> {
        private LambdaExpression ConditionClausePredicate { get; set; }
		private ParameterExpression Parameter { get; set; }
		public void Visit(Filter filter) {
			if (filter == null) {
				return;
			}
			if (this.Parameter == null) {
				this.Parameter = Expression.Parameter(filter.BaseType, "x");
			}
			ConditionClausePredicate = And(filter);
		}
		public Delegate GetConditionClause() {
			if (ConditionClausePredicate != null) {
				return ConditionClausePredicate.Compile();
			}
			return null;
		}
		private LambdaExpression And(Filter filter) {
			if (filter.BaseType == null || string.IsNullOrWhiteSpace(filter.FlattenPropertyName)) {
				//Something is wrong, passing by current filter
				return ConditionClausePredicate;
			}
			var conditionType = filter.GetCondition();
			var propertyExpression = filter.BaseType.GetFlattenPropertyExpression(filter.FlattenPropertyName, this.Parameter);
			switch (conditionType) {
				case FilterCondition.Equal: {
					var matchValue = TypeDescriptor.GetConverter(propertyExpression.ReturnType).ConvertFromString(filter.Match);
					var propertyValue = Expression.Constant(matchValue, propertyExpression.ReturnType);
					var equalExpression = Expression.Equal(propertyExpression.Body, propertyValue);
					if (ConditionClausePredicate == null) {
						ConditionClausePredicate = Expression.Lambda(equalExpression, this.Parameter);
					} else {
						ConditionClausePredicate = Expression.Lambda(Expression.And(ConditionClausePredicate.Body, equalExpression), this.Parameter);
					}
					break;
				}
            // and so on...
        }
    }
