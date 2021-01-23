    public static IQueryable<Mission> MissionWithRequired(this IOrgDatenbankContext context)
    {
       var requiredProperties = typeof(Mission).GetProperties()
                .Where(property => Attribute.IsDefined(property, typeof(RequiredAttribute)));
       IQueryable<Mission> result = context.Missions;
       foreach (var requiredProperty in requiredProperties)
       {
          result = result.Include(requiredProperty.Name);
       }
       return result;
    }
