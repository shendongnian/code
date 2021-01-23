     public static class AutoMapperConfiguration
     {
        public static void Configure()
        {
          ConfigureSomeMapping();
        }
        private static void ConfigureSomeMapping()
        {
           Mapper.CreateMap<...>();
         } 
      }
