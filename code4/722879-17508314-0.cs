    public List<ReferenceTypeDto> GetAllResourceTypes()
    {
        var unordered = rd.GetAllResourceTypes();
        var ordered = unordered.OrderByDescending(t => t.Weight).ToList();
        return ordered;
    }
