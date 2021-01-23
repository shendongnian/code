    class Process
    {
        public int UserId { get; set; }
        public int AccountNo { get; set; }
    }
    Process(p => new { UserId = p.UserId, p.AccountNo });    
    public static void Process<T>(Expression<Func<Process, T>>  expression)
    {
        var newExpression = (NewExpression) expression.Body;
        var propertiesAssignement =
            newExpression.Type.GetProperties().Zip(
                newExpression.Arguments.OfType<MemberExpression>(),
                (p, m) => new {ProjectedName = p.Name, RealName = m.Member.Name}
            );
    }
