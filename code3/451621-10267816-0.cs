    public static IQueryable<LogViewer.EF.InternetEF.Log> ExecuteInternetGetLogsQuery(FilterCriteria p_Criteria, ref GridView p_Datagrid)
            {
    
                
                IQueryable<LogViewer.EF.InternetEF.Log> internetQuery = null;
                List<LogViewer.EF.InternetEF.Log> executedList = null;
                using (InternetDBConnectionString context = new InternetDBConnectionString())
                {
                    internetQuery = context.Logs;
                    if ((p_Criteria.DateTo != null && p_Criteria.DateFrom != null))
                    {
                        internetQuery = internetQuery.Where(c => c.Timestamp >= p_Criteria.DateFrom.Value && c.Timestamp < p_Criteria.DateTo.Value);
                    }
                    else if (p_Criteria.DateFrom != null && p_Criteria.DateFrom > DateTime.MinValue)
                    {
                        internetQuery = internetQuery.Where(c => c.Timestamp >= p_Criteria.DateFrom);
                    }
                    else if (p_Criteria.DateTo != null && p_Criteria.DateTo > DateTime.MinValue)
                    {
                        internetQuery = internetQuery.Where(c => c.Timestamp < p_Criteria.DateTo);
                    }
                    if (!string.IsNullOrEmpty(p_Criteria.FreeText))
                    {
                        internetQuery = internetQuery.Where(c => c.FormattedMessage.Contains(p_Criteria.FreeText));
                    }
    
                    
                    if (p_Criteria.Titles.Count > 0)
                    {
                        internetQuery = internetQuery.Where(BuildOrExpression<LogViewer.EF.InternetEF.Log, string>(p => p.Title, p_Criteria.Titles));
                    }
                    if (p_Criteria.MachineNames.Count > 0)
                    {
                        internetQuery = internetQuery.Where(BuildOrExpression<LogViewer.EF.InternetEF.Log, string>(p => p.MachineName, p_Criteria.MachineNames));
                    }
                    if (p_Criteria.Severities.Count > 0)
                    {
                        internetQuery = internetQuery.Where(BuildOrExpression<LogViewer.EF.InternetEF.Log, string>(p => p.Severity, p_Criteria.Severities));
                    }
    
    
                    internetQuery = internetQuery.Take(p_Criteria.TopValue);
                    executedList = internetQuery.ToList<LogViewer.EF.InternetEF.Log>();
                    executedList = executedList.OrderByDescending(c => c.LogID).ToList<LogViewer.EF.InternetEF.Log>(); ;
    
                    p_Datagrid.DataSource = executedList;
    
                    p_Datagrid.DataBind();
    
    
                    return internetQuery;
    
                }
            }
 
    public static Expression<Func<TElement, bool>> BuildOrExpression<TElement, TValue>(
            Expression<Func<TElement, TValue>> valueSelector,
            IEnumerable<TValue> values )
            {
                if (null == valueSelector)
                    throw new ArgumentNullException("valueSelector");
    
                if (null == values)
                    throw new ArgumentNullException("values");
    
                ParameterExpression p = valueSelector.Parameters.Single();
    
                if (!values.Any())
                    return e => false;
    
                var equals = values.Select(value =>
                    (Expression)Expression.Equal(
                         valueSelector.Body,
                         Expression.Constant(
                             value,
                             typeof(TValue)
                         )
                    )
                );
    
                var body = equals.Aggregate<Expression>(
                         (accumulate, equal) => Expression.Or(accumulate, equal)
                 );
    
                return Expression.Lambda<Func<TElement, bool>>(body, p);
            }
