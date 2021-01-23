    public class MyRepository
    {
      public ICacheProvider Cache { get; set; }
    }
    container.RegisterType<MyRepository>(new InjectionProperty("Cache", typeof(ICacheProvider)));
