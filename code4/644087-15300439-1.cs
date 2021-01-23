    public List<Facility> GetFacilities()
    {
        return _facilityRepository.GetAll()
            .Where(x => x.Fac_Name == "Something")
            .DistinctBy(x => new
            {
                ID = x.Fac_Name.Substring(0, 6),
                Fac_Name = x.Fac_Name.Substring(0, 3)
            })
            .OrderBy(x => x.Fac_Name)
            .ToList();
    }
