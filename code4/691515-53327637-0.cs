    public BusinessStructureFilterSpecification(int responsibilityTypeId, bool dummy1 = true) : base(x => x.ResponsibleGroups.Any(x1 => x1.ResponsibilityTypeId == responsibilityTypeId))
    {
        AddIncludes();
    }
    public BusinessStructureFilterSpecification(int userId, string dummy2 = "") : base(x => x.ResponsibleUsers.Any(x1 => x1.UserId == userId))
    {
        AddIncludes();
    }
