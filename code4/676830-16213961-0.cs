    public static List<AttributeDetails> GetFilteredAttributeList(string pEntityName, string pAttributeFilter)
        {
            var entityList = new List<EntityDetails>(); //added just to makte it compile
            var filtered =
                from entity in entityList
                where entity.EntityName == pEntityName
                from attribute in entity.Attributes
                where attribute.AttributeName.Contains(pAttributeFilter)
                select attribute;
            return filtered.ToList();
        }
