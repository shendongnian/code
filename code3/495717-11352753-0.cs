    /// <summary>
    /// Maps a property value from one object type to another.
    /// Assignment only if values are different.
    /// Change is recorded to stringbuilder object with changeName name
    /// </summary>
    /// <typeparam name="TDestination">Type of destination object</typeparam>
    /// <typeparam name="TSource">Type of source object</typeparam>
    /// <param name="changeName">what to call the change for logging</param>
    /// <param name="dObj">the desitnation object instance on which to call the extension method</param>
    /// <param name="d">destination property</param>
    /// <param name="sObj">the source object instance</param>
    /// <param name="s">source property</param>
    /// <param name="sbChanges">where to log the changes</param>
    /// <returns>1 if values were different, 0 if values were the the same</returns>
    /// <example>
    ///     var sbChanges = new StringBuilder();
    ///     var c = 0;
    ///     c += DestObj.MapChanges("My Property", x => x.DestProp, SourceObj, x => x.SourceProp, sbChanges);
    /// </example>
    public static short MapChanges<TDestination, TSource>(this TDestination dObj, string changeName, Expression<Func<TDestination, object>> d,
                                                          TSource sObj, Expression<Func<TSource, object>> s, StringBuilder sbChanges)
    {
        var dExpr = d.Body as MemberExpression ?? ((UnaryExpression)d.Body).Operand as MemberExpression;
        var sExpr = s.Body as MemberExpression ?? ((UnaryExpression)s.Body).Operand as MemberExpression;
    
        if (dExpr == null)
            throw new Exception("Destination expression must be a field or property");
    
        if (sExpr == null)
            throw new Exception("Source expression must be a field or property");
    
        var dProp = typeof(TDestination).GetProperty(dExpr.Member.Name);
        var sProp = typeof(TSource).GetProperty(sExpr.Member.Name);
    
        var dVal = dProp.GetValue(dObj, null);
        var sVal = sProp.GetValue(sObj, null);
    
        //Equals(null, null) is false so also compare by reference
        if (!ReferenceEquals(dVal, sVal) && !Equals(dVal, sVal))
        {
            dProp.SetValue(dObj, sVal, null);
    
            bool o;
            if (Boolean.TryParse(sVal.ToString(), out o)) //boolean
                sbChanges.AppendFormat("Set '{0}' to {1}\r", changeName, sVal);
            else //other types
                sbChanges.AppendFormat("Set '{0}' from {1} to {2}\r", changeName, dVal, sVal);
    
            return 1;
        }
    
        return 0;
    }
