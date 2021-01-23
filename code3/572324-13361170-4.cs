    public class MyMappedClassesProfile: Profile
    {
        protected override void Configure()
        {
            CreateMap<Foo1, Foo2>();//nb, Don't call static Mapper.CreateMap here
        }
    }
    Mapper.AddProfile<MyMappedClassesProfile>();
