    string s = GetPropertyName<User>( x=> x.Name );
    public string GetPropertyName<T>(Expression<Func<T, object>> lambda)
    {
        var member = lambda.Body as MemberExpression;
        var prop = member.Member as PropertyInfo;
        return prop.Name;
    }
---
    public class User
    {
        public string Name { set; get; }
    }
