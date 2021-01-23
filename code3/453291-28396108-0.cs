    /// <summary>
    ///     Helper class for scanning assemblies and automatically adding AutoMapper.Profile
    ///     implementations to the AutoMapper Configuration.
    /// </summary>
    public static class AutoProfiler
    {
        public static void RegisterReferencedProfiles()
        {
            AppDomain.CurrentDomain
                .GetReferencedTypes()
                .Where(type => type != typeof(Profile) 
                  && typeof(Profile).IsAssignableFrom(type) 
                  && !type.IsAbstract)
                .ForEach(type => Mapper.Configuration.AddProfile(
                  (Profile)Activator.CreateInstance(type)));
        }
    }
