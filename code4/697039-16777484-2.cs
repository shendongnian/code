    public PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> lambda)
    {
        var member = lambda.Body as MemberExpression;
        return member.Member as PropertyInfo;
    }
---
    public class User
    {
        public string Name { set; get; }
    }
