    public class ViewModelProfile : Profile
    {
    	public override string ProfileName
    	{
    		get { return "ViewModel"; }
    	}
    
    	protected override void Configure()
    	{
    		CreateMap<Customer, CustomerWithOrdersModel>()
    			.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => string.Format("{0}, {1}", src.LastName, src.FirstName)))
    			.ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders.ToList()));
    	}
    }
