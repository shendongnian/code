    Mapper.CreateMap<AccountUpdate, User>()
            .ForMember(d => d.Roles, s => s.Ignore())
            .ForMember(d => d.UserId, s => s.Ignore())
            .ForMember(d => d.Password, s => s.Ignore())
            .ForMember(d => d.Salt, s => s.Ignore())
            .ForMember(d => d.CreatedOn, s => s.Ignore())
            .ForMember(d => d.LastLogin, s => s.Ignore());
    Mapper.AssertConfigurationIsValid();
    var update = new AccountUpdate
    {
        Email = "foo@bar.com",
        Name = "The name",
        Roles = "not important"
    };
    var user = Mapper.Map<AccountUpdate, User>(update);
    Trace.Assert(user.Email == update.Email);
    Trace.Assert(user.Name == update.Name);
