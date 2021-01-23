	public class Profile1 : Profile
	{
		protected override void Configure()
		{
			base.CreateMap<User, User>();
		}
	}
	public class Profile2 : Profile
	{
		protected override void Configure()
		{
			base.CreateMap<User, User>().ForMember(dest => dest.Age, opt => opt.Ignore());
		}
	}
	public class CommonProfile : Profile
	{
		protected override void Configure()
		{
			base.CreateMap<Vehicle, Vehicle>();
		}
	}
