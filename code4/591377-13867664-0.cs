    public class MyProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "MyProfile";
            }
        }
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<AccountBO, UserAccount>();
            AutoMapper.Mapper.CreateMap<AddressBO,UserAccount>();
        }
    }
