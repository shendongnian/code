    Mapper.CreateMap<Z, Destination>();
    Mapper.CreateMap<Y, Destination>();
    Mapper.CreateMap<X, Destination>()
        .ForMember(destination => destination.A, options => options.MapFrom(source => source.A)).IgnoreAllNonExisting()
        .ForMember(destination => destination.C, options => options.MapFrom(source => Mapper.Map<IEnumerable<Y>, IEnumerable<Destination>>(source.B).FirstOrDefault().C))
        .ForMember(destination => destination.E, options => options.MapFrom(source => Mapper.Map<IEnumerable<Z>, IEnumerable<Destination>>(source.B.SelectMany(d => d.D)).FirstOrDefault().E))
        .ForMember(destination => destination.F, options => options.MapFrom(source => Mapper.Map<IEnumerable<Z>, IEnumerable<Destination>>(source.B.SelectMany(d => d.D)).FirstOrDefault().F));
    var result = Mapper.Map<IEnumerable<X>, IEnumerable<Destination>>(arrayOfX);
