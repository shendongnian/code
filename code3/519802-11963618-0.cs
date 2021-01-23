        public static IQueryable<Investment> PerformanceSearch(IQueryable<Investment> investment, Expression<Func<Investment, double>> searchColumn, double minValue, double maxValue) {
            // LINQ Expression that represents the column passed in searchColumn
            // x.Return1Month
            MemberExpression columnExpression = searchColumn.Body as MemberExpression;
            // LINQ Expression to represent the parameter of the lambda you pass in
            // x
            ParameterExpression parameterExpression = (ParameterExpression)columnExpression.Expression;
            // Expressions to represent min and max values
            Expression minValueExpression = Expression.Constant(minValue);
            Expression maxValueExpression = Expression.Constant(maxValue);
            // Expressions to represent the boolean operators
            // x.Return1Month >= minValue
            Expression minComparisonExpression = Expression.GreaterThanOrEqual(columnExpression, minValueExpression);
            // x.Return1Month <= maxValue
            Expression maxComparisonExpression = Expression.LessThanOrEqual(columnExpression, maxValueExpression);
            // (x.Return1Month >= minValue) && (x.Return1Month <= maxValue)
            Expression filterExpression = Expression.AndAlso(minComparisonExpression, maxComparisonExpression);
            // x => (x.Return1Month >= minValue) && (x.Return1Month <= maxValue)
            Expression<Func<Investment, bool>> filterLambdaExpression = Expression.Lambda<Func<Investment, bool>>(filterExpression, parameterExpression);
            // use the completed expression to filter your collection (requires the collection to be IQueryable)
            return investment.Where(filterLambdaExpression);
                        
        }
