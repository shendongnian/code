    Context context=new Context();
    Public List<LocationEntity> GetAll()
    {
        return context.LocationEntities.Include("includeProperty").ToList();
    }
