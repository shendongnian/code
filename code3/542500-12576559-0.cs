    _attributeGroups = attributeGroups.Select(attributeGroupRowModel => 
    {
        var wt = workTypes.First(x => x.Id == attributeGroupRowModel.WorkTypeId);
        return new AttributeGroupRowModel()
        {
            Name = attributeGroupRowModel.Name,               
            WorkType = wt.Description,
            IsExpired = wt.IsExpired,
        };
    }).ToList();
