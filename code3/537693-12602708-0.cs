    [TestMethod]
    public void TestMethod1()
    {
         Mapper.CreateMap<AccountViewModel, Account>()
            .ForMember(dest => dest.DateToBeIgnored, opt => opt.Ignore())
            .ForMember(dest=>dest.Settings, opt=>opt.UseDestinationValue());
        Mapper.CreateMap<AccountSettingViewModel, AccountSetting>()
            .ForMember(dest=>dest.PropertyOne, opt=>opt.Ignore())
            .ForMember(dest => dest.PropertyTwo, opt => opt.MapFrom(a => a.PropertyTwo));
        Mapper.AssertConfigurationIsValid();
        AccountViewModel viewmodel = new AccountViewModel()
        {
            AccountId = 3,
            DateToBeIgnored = DateTime.Now,
            Settings = new AccountSettingViewModel() { PropertyTwo = "AccountSettingViewModelPropTwo" }
        };
        Account account = new Account()
        {
            AccountId = 10,
            DateToBeIgnored = DateTime.Now,
            Settings = new AccountSetting() { PropertyOne = "AccountPropOne", PropertyTwo = "AccountPropTwo" }
        };
        account = Mapper.Map<AccountViewModel, Account>(viewmodel, account);
        Assert.IsNotNull(account);
    }
