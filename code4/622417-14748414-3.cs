    
    // first a small helper, which creates the member and checks nullable fields
    public static Expression getExpressionPart(ParameterExpression param,
      String s1, String s2)
    {
        Expression member = null;
        if (s2 == null)
        {
            member = Expression.Property(param, s1);
        }
        else
        {
            // the second string is to deal with foreign keys/related data
            member = Expression.PropertyOrField(
              Expression.PropertyOrField(param, s1), s2
            );
        }
        Type typeIfNullable = Nullable.GetUnderlyingType(member.Type);
        if (typeIfNullable != null)
        {
            member = Expression.Call(member, "GetValueOrDefault", Type.EmptyTypes);
        }
    }
