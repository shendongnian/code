    private static string GetMethodName( Expression<Action<int>> e )
    {
        Debug.WriteLine( "e.Body.NodeType is {0}", e.Body.NodeType );
        MethodCallExpression mce = e.Body as MethodCallExpression;
        if ( mce != null ) {
            return mce.Method.Name;
        }
        InvocationExpression ie = e.Body as InvocationExpression;
        if ( ie != null ) {
            var me = ie.Expression as MemberExpression;
            if ( me != null ) {
                var prop = me.Member as PropertyInfo;
                if ( prop != null ) {
                    var v = prop.GetValue( null ) as Delegate;
                    return v.Method.Name;
                }
            }
        }
        return "ERROR";
    }
