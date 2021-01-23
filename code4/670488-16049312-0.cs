    public List<DropdownViewModel> Get()
    {
        return Enum.GetValues(typeof(CountryEnum))
            .Select(id => new DropdownViewModel {
                id = id,
                name = Enum.GetName(typeof(CountryEnum), id)
            }).ToList();
    }
