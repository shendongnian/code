	Mapper.Initialize(cfg =>
	{
		cfg.CreateMap<Foo, FooViewModel>()
		   .ForMember(dest => dest.BarViewModel,
                      opt  => opt.MapFrom<NullBarResolver, Bar>(src => src.Bar));
		cfg.CreateMap<Bar, BarViewModel>();
	});
    public class NullBarResolver : IMemberValueResolver<object, object, Bar, BarViewModel>
    {
        public BarViewModel Resolve(object source, object destination, Bar sourceMember,
                                    BarViewModel destMember, ResolutionContext context)
        {
            if (sourceMember == null)
                return new BarViewModel();
            return Mapper.Map(sourceMember, destMember);
        }
    }
