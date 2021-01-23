    Mapper.CreateMap<Order, OrderDto>()
      .Include<OnlineOrder, OnlineOrderDto>()
      .Include<MailOrder, MailOrderDto>()
      .ForMember(o=>o.Id, m=>m.MapFrom(s=>s.OrderId));
    Mapper.CreateMap<OnlineOrder, OnlineOrderDto>();
    Mapper.CreateMap<MailOrder, MailOrderDto>();
