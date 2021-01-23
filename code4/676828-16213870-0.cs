    public static IEnumerable<AttributeDetails> GetFilteredAttributeList(
      string pEntityName, string pAttributeFilter) {
      return entityList
        .Where(e => e.EntityName == pEntityName)
        .Select(e => e.Attributes
          .Where (a => a.AttributeName.Contains (pAttributeFilter)
        )
      );
    }
