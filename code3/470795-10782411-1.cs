    public BaseService()
	{
		AutoMapperRegistry.Configure();
	}
		
	public class AutoMapperRegistry
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ServiceProfile1>();
                x.AddProfile<ServiceProfileReverseProfile1>();
            });
        }
    }
	
	public class ServiceProfile1 : Profile
    {
        protected override string ProfileName
        {
            get
            {
                return "ServiceProfile1";
            }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<DataContract_Sub, DTO_Sub>();
            Mapper.CreateMap<DataContract, DTO>()
                .ForMember(x => x.DataContract_Sub, opt => opt.MapFrom(y => y.DTO_Sub))
		.BeforeMap((s, d) => 
                {
                    // your custom logic
                })
		.AfterMap((s, d) => 
                {
                    // your custom logic
                });
        }
    }
