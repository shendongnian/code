    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderDto>(MemberList.None)
                .ForMember(dest => dest.OrderId,
                    opts => opts.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.OrderDate,
                    opts => opts.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.OrderedBy,
                    opts => opts.MapFrom(src => src.OrderedBy))
                .ForMember(dest => dest.ItemsDto,
                    opt => opt.MapFrom(src => src.Items));
        }
    }
