    var attributes = _entities.Attributes.ToList().Select(a => new SelectListItem
                        {
                            Text = a.AttributeName,
                            Value = a.AttributeID.ToString()
                        }).Concat(_entities.AttributeTypes.ToList().Select(a => new SelectListItem
                        {
                            Text = a.AttributeTypeCode,
                            Value = a.AttributeTypeID.ToString()
                        }).Distinct().ToList());
        
                        return attributes.ToList();
