    public static void Configure()
    {
        Mapper.CreateMap<User, UserFull>();
        Mapper.CreateMap<TaskTime, UserTaskTime>();
        Mapper.AssertConfigurationIsValid();
    }
