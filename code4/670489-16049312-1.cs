    public List<DropdownViewModel> Get()
    {
        return Enum.GetValues(typeof (CountryEnum)).Cast<int>()
            .Select(id => new DropdownViewModel
            {
                id = id,
                name = Enum.GetName(typeof (CountryEnum), id)
            }).ToList();
    }
