    var arrayOfX = new X[]  { new X { A = "String A", B = new Y[] { new Y { C = "String C", D = new Z[] {new Z {E = "String E", F = "String F"}}}}}};
    Mapper.CreateMap<X, Destination>()
        .ForMember(destination => destination.A, options => options.MapFrom(source => source.A))
        .ForMember(destination => destination.C, options => options.MapFrom(source => source.B.Select(y => y.C).First()))
        .ForMember(destination => destination.E, options => options.MapFrom(source => source.B.Select(y => y.D).First().Select(z => z.E).First()))
        .ForMember(destination => destination.F, options => options.MapFrom(source => source.B.Select(y => y.D).First().Select(z => z.F).First()));
    var result = Mapper.Map<IEnumerable<X>, IEnumerable<Destination>>(arrayOfX);
