    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserRepository>().As<IUserReposotory>();
        builder.RegisterType<MyMembershipProvider>();
    }
