    public List<SelectListItem> GetAttributeName() 
    { 
       return _entities.Attributes
                       .Select(a => new SelectListItem {
                             Text = a.AttributeName,
                             Value = a.AttributeID.ToString() })
                       .Concat(_entities.Attributes.AsEnumerable()
                                       .Select(a => new SelectListItem {
                             Text = a.AttributeType.AttributeTypeCode.ToString(),
                             Value = a.AttributeID.ToString() })
                       .ToList();
    }
