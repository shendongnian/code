    public static Expression<Func<T, bool>> BuildEmailAddressLambda<T>(
        string member, IEnumerable<object> memberArgs, string method, params object[] args)
    {
        var e = Expression.Parameter(typeof(T), "e");
        var memberInfo =
            (MemberInfo) typeof(T).GetField(member) ??
            (MemberInfo) typeof(T).GetProperty(member) ??
            (MemberInfo) typeof(T).GetMethod(member, (memberArgs ?? Enumerable.Empty<object>()).Select(p => p.GetType()).ToArray());
        Expression m;
        if (memberInfo.MemberType == MemberTypes.Method)
        {
            var a = memberArgs.Select(p => Expression.Constant(p));
            m = Expression.Call(e, (MethodInfo) memberInfo, a);
        }
        else
        {
            m = Expression.MakeMemberAccess(e, memberInfo);
        }
        var mi = m.Type.GetMethod(method, args.Select(a => a.GetType()).ToArray());
        var c = args.Select(a => Expression.Constant(a, a.GetType()));
        return Expression.Lambda<Func<T, bool>>(Expression.Call(m, mi, c), e);
    }
    // called:
    lambda = LambdaExpressionHelper<MailingListMember>.BuildEmailAddressLambda("EmailAddress", null, "StartsWith", "r", StringComparison.OrdinalIgnoreCase);
    // or
    lambda = LambdaExpressionHelper<MailingListMember>.BuildEmailAddressLambda("GetStringValue", new object[] { 12 }, "StartsWith", "r", StringComparison.OrdinalIgnoreCase);
