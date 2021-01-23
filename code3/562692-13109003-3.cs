    class CleanRiders
    {
        List<Rider> GetCleanRiders()
        {
            var riderRepository = new MsSqlRiderRepository();
            riderRepository.GetRiders.Where(x => x.Doping == false);
        }
    }
