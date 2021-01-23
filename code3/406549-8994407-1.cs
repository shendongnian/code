    public IList<GetLocationDetailsResponse> GetLocationUpdate(DateTime lastUpdateTimeDT)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var locations = GetLocations.LoadReturnLocationsFromDatabase(session, lastUpdateTimeDT);
            return Mapper.Map<IList<Location>, IList<GetLocationDetailsResponse>>(locations);
        }
    }
