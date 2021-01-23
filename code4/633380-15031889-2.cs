    private IEnumerable<Guid> GetGuidsByEmail(String email)
    {
      QueryExpression query = new QueryExpression
      {
        EntityName = "lead",
        ColumnSet = new ColumnSet("emailaddress1")
      };
      IEnumerable<Entity> entities = service.RetrieveMultiple(query).Entities;
    
      return entities
        .Where(element => element.Contains("emailaddress1"))
          .Where(element => Regex.IsMatch(element["emailaddress1"], email))
            .Select(element => element.Id);
    }
