    public class OrderItemMapper : Profile
    {
        public OrderItemMapper()
        {
            CreateMap<OrderItem, OrderItemDto>(MemberList.None)
                .ForMember(dest => dest.ItemId,
                    opts => opts.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.ItemPrice,
                    opts => opts.MapFrom(src => src.ItemPrice))
                .ForMember(dest => dest.Name,
                    opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Quantity,
                    opts => opts.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ItemTotal,
                    opts => opts.MapFrom(src => src.ItemTotal));
        }
    
    }
