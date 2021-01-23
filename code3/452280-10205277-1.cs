static class PropertyInfoProvider&lt;T&gt;
{
    public static PropertyInfo GetPropertyInfo&lt;TProperty&gt;(Expression&lt;Func&lt;T, TProperty&gt;&gt; expression)
    {
        var memberExpression = (MemberExpression)expression.Body;
        return (PropertyInfo)memberExpression.Member;
    }
}
class PropertiesListBuilder&lt;T&gt;
{
    public IEnumerable&lt;PropertyInfo&gt; Properties
    {
        get
        {
            return this.properties;
        }
    }
    public PropertiesListBuilder&lt;T&gt; AddProperty&lt;TProperty&gt;(
        Expression&lt;Func&lt;T, TProperty&gt;&gt; expression)
    {
        var info = PropertyInfoProvider&lt;T&gt;.GetPropertyInfo(expression);
        this.properties.Add(info);
        return this;
    }
    private List&lt;PropertyInfo&gt; properties = new List&lt;PropertyInfo&gt;();
}
