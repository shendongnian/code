    public static class AutoMapperBootstrapper
    {
        public static void AddMappings()
        {
            Mapper.AddProfile<MyProfile>();
        }
    }
