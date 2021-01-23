    protected override EdmProperty MatchKeyProperty(EdmEntityType entityType, IEnumerable<EdmProperty> primitiveProperties)
    {
        return primitiveProperties.SingleOrDefault<EdmProperty>(delegate {
            return string.Concat(entityType.Name, "Id").Equals(p.Name, stringComparison);
        }) ?? primitiveProperties.SingleOrDefault<EdmProperty>(delegate {
            return string.Concat(entityType.Name, "Id").Equals(p.Name, stringComparison);
        });
    }
