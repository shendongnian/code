    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            // register all profiles in container
            AppDomain.CurrentDomain
                .GetReferencedTypes()
                .Where(type => type != typeof(Profile)
                  && typeof(Profile).IsAssignableFrom(type) 
                  && !type.IsAbstract)
                .ForEach(type => builder
                    .RegisterType(type)
                    .As<Profile>()
                    .PropertiesAutowired());
            // register mapper
            builder
                .Register(
                    context =>
                    {
                        // register all profiles in AutoMapper
                        context
                            .Resolve<IEnumerable<Profile>>()
                            .ForEach(Mapper.Configuration.AddProfile);
                        // register object mapper implementation
                        return new AutoMapperObjectMapper();
                    })
                .As<IObjectMapper>()
                .SingleInstance()
                .AutoActivate();
        }
    }
