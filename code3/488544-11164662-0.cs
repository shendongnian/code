    class Program
    {
        const string conString = @"myDB";
    
        static void Main(string[] args)
        {
            Expression<Func<string, DateTime, byte, long, bool>> expression = (jobName, ranAt, resultCode, elapsed) => jobName == "Email Notifications" && resultCode == (byte)ResultCode.Failed;
            var criteria = ConvertExpression(expression);
    
            using (MyDataContext dataContext = new MyDataContext(conString))
            {
                List<svc_JobAudit> jobs = dataContext.svc_JobAudit.Where(criteria).ToList();
            }
        }
    
        private static Expression<Func<svc_JobAudit, bool>> ConvertExpression(Expression<Func<string, DateTime, byte, long, bool>> expression)
        {
            var jobAuditParameter = Expression.Parameter(typeof(svc_JobAudit), "jobAudit");
            var newExpression = Expression.Lambda<Func<svc_JobAudit, bool>>(new ReplaceVisitor().Modify(expression.Body, jobAuditParameter), jobAuditParameter);
            return newExpression;
        }
    }
    
    class ReplaceVisitor : ExpressionVisitor
    {
        private ParameterExpression parameter;
    
        public Expression Modify(Expression expression, ParameterExpression parameter)
        {
            this.parameter = parameter;
            return Visit(expression);
        }
    
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            return Expression.Lambda<Func<svc_JobAudit, bool>>(Visit(node.Body), Expression.Parameter(typeof(svc_JobAudit)));
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == typeof(string))
            {
                return Expression.Property(parameter, "JobName");
            }
            else if (node.Type == typeof(DateTime))
            {
                return Expression.Property(parameter, "RanAt");
            }
            else if (node.Type == typeof(byte))
            {
                return Expression.Property(parameter, "Result");
            }
            else if (node.Type == typeof(long))
            {
                return Expression.Property(parameter, "Elapsed");
            }
            throw new InvalidOperationException();
        }
    }
