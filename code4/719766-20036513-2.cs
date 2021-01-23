    public static IQueryable<TItem> HasFlags<TItem, TProperty>(
        this IQueryable<TItem> items,
        Expression<Func<TItem, TProperty>> itemPropertyExpression,
        params Enum[] enumFlags)
    {
        var enumFlagNames = enumFlags.Select(enumFlag => (BsonValue)enumFlag.ToString());
        return items.Where(item => Query.In(ExtendedObject.GetPropertyName(itemPropertyExpression), enumFlagNames).Inject());
    }
