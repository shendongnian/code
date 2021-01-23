    /// <summary>
    /// Maps a property value from one object type to another.
    /// Assignment only if values are different.
    /// Change is recorded to stringbuilder object with changeName name
    /// </summary>
    /// <typeparam name="TDestination">Type of destination object</typeparam>
    /// <typeparam name="TSourceValue">Type of source object</typeparam>
    /// <param name="changeName">what to call the change for logging</param>
    /// <param name="dObj">the desitnation object instance on which to call the extension method</param>
    /// <param name="destProp">destination (old value) property</param>
    /// <param name="sVal">the source (new) value</param>
    /// <param name="sbChanges">where to log the changes</param>
    /// <returns>1 if values were different, 0 if values were the the same</returns>
    /// <example>
    ///     var sbChanges = new StringBuilder();
    ///     var c = 0;
    ///     c += DestObj.MapChange("My Property", x => x.DestProp, SourceObj.SourceProp, sbChanges);
    /// </example>
    public static short MapChange<TDestination, TSourceValue>(this TDestination dObj, string changeName, Expression<Func<TDestination, object>> destProp,
                                                          TSourceValue sVal, StringBuilder sbChanges)
    {
        var dExpr = destProp.Body as MemberExpression ?? ((UnaryExpression)destProp.Body).Operand as MemberExpression;
        
        if (dExpr == null)
            throw new Exception("Destination expression must be a field or property");
    
        var dProp = typeof(TDestination).GetProperty(dExpr.Member.Name);
    
        var dVal = dProp.GetValue(dObj, null);
    
        //Equals(null, null) is false so also compare by reference
        if (!ReferenceEquals(dVal, sVal) && !Equals(dVal, sVal))
        {
            dProp.SetValue(dObj, sVal, null);
    
            if (sVal == null) // http://stackoverflow.com/questions/5340817/what-should-i-do-about-possible-compare-of-value-type-with-null
                sbChanges.AppendFormat("Removed '{0}'\r", changeName);
            else if (dVal == null || sVal is bool)
                sbChanges.AppendFormat("Set '{0}' to '{1}'\r", changeName, sVal);
            else //other types
                sbChanges.AppendFormat("Set '{0}' from '{1}' to '{2}'\r", changeName, dVal, sVal);
    
            return 1;
        }
    
        return 0;
    }
