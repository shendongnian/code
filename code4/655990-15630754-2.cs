    public List<SelectListItem> GetAttributeName() 
    { 
       var attributes = _entities.Attributes
                                 .Select(a => new { 
                                      a.AttributeName,
                                      a.AttributeType.AttributeTypeCode,
                                      a.AttributeID
                                 }).ToList();
       return attributes.Select(a => new SelectListItem {
                             Text = a.AttributeName,
                             Value = a.AttributeID.ToString() })
                        .Concat(attributes.Select(a => new SelectListItem {
                             Text = a.AttributeTypeCode.ToString(),
                             Value = a.AttributeID.ToString() })
                        .ToList();
    }
