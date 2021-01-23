    public class A
        {
            static A()
            {
                Mapper.Initialize(
                    config =>
                    {
                        config.ForSourceType<B>().AllowNullDestinationValues = false;
                        config.CreateMap<B, A>()
                            .ForMember(member => member.Name, opt => opt.Ignore());
                    });
                Mapper.Configuration.AllowNullDestinationValues = false;
    
                Mapper.AssertConfigurationIsValid();
            }
    
            public void Init(B b)
            {
                Mapper.DynamicMap(b, this);
            }
    
            public int? Foo { get; set; }
            public double? Foo1 { get; set; }
            public bool Foo2 { get; set; }
            public string Name { get; set; }
        }
