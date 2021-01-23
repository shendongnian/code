    // For mapping from service entity to book
    Mapper.Initialize(cfg => cfg.RecognizePrefixes("Bk"));
    Mapper.CreateMap<BusinessEntity, ServiceEntity>();
    
    // Trick to un-flatten service entity
    // It is mapped both to Book and BusinessEnity
    Mapper.CreateMap<ServiceEntity, Book>();
    Mapper.CreateMap<ServiceEntity, BusinessEntity>()
            .ForMember(d => d.Bk, m => m.MapFrom(s => s));
