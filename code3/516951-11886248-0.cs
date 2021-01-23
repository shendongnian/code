    public class LinqBuilder
    {
        /// <summary>
        /// Build a LINQ Expression that roughly matches the SQL IN() operator
        /// </summary>
        /// <param name="columnValues">The values to filter for</param>
        /// <returns>An expression that can be passed to the LINQ  .Where() method</returns>
        public static Expression<Func<RowType, bool>> BuildListFilter<RowType, ColumnType>(string filterColumnName, IEnumerable<ColumnType> columnValues)
        {
            ParameterExpression rowParam = Expression.Parameter(typeof(RowType), "r");
            MemberExpression column = Expression.Property(rowParam, filterColumnName);
                
            BinaryExpression filter = null;
            foreach (ColumnType columnValue in columnValues)
            {
                BinaryExpression newFilterClause = Expression.Equal(column, Expression.Constant(columnValue));
                if (filter != null)
                {
                    filter = Expression.Or(filter, newFilterClause);
                }
                else
                {
                    filter = newFilterClause;
                }
            }
    
            return Expression.Lambda<Func<RowType, bool>>(filter, rowParam);
        }
    
        public static Expression<Func<RowType, bool>> BuildComparisonFilter<RowType, ColumnType>(string filterColumnName, Func<MemberExpression, BinaryExpression> buildComparison)
        {
            ParameterExpression rowParam = Expression.Parameter(typeof(RowType), "r");
            MemberExpression column = Expression.Property(rowParam, filterColumnName);
    
            BinaryExpression filter = buildComparison(column);
            return Expression.Lambda<Func<RowType, bool>>(filter, rowParam);
        }
