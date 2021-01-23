    public class Foo
    {
        public Bar Bar { get; set; }
    }
    public class Foo2
    {
        public Bar Bar { get; set; }
    }
    public class Bar
    {
        public int Id { get; set; }
        public Bar()
        {
            Id = 3;
        }
    }
    CreateMap<Foo, Foo2>()
        .ForMember(
            dest => dest.Bar,
            opt => opt.MapFrom(src => src.Bar == null ? new Bar() : src.Bar));
