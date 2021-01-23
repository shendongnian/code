    public class AutoMapperGlobalConfiguration : IGlobalConfiguration
        {
            private readonly IConfiguration _configuration;
    
            public AutoMapperGlobalConfiguration(IConfiguration configuration)
            {
                _configuration = configuration;
            }
    
            private void RegisterAssembly(Assembly assembly)
            {
                //add all defined profiles
                var query = assembly.GetExportedTypes()
                    .Where(x => x.CanBeCastTo(typeof(Profile)));
    
                foreach (Type type in query)
                {
                    var profile = ObjectFactory.GetInstance(type).As<Profile>();
                    _configuration.AddProfile(profile);
    
                  
                    Mapper.AddProfile(profile);
    
                }
            }
    
            public void Configure()
            {
                _configuration.RecognizePostfixes("Id");
    
                var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("DM."));
    
                //create maps for all Id2Entity converters
                MapAllEntities(_configuration);
    
                assemblies.Each(RegisterAssembly);
            }
    
            private static void MapAllEntities(IProfileExpression configuration)
            {
                //get all types from the domain assembly and create maps that
                //convert int -> instance of the type using Id2EntityConverter
                var openType = typeof(Id2EntityConverter<>);
                var idType = typeof(int);
                  
                var persistentEntties = typeof(Domain.Entities).Assembly.GetTypes()
                   .Where(t => typeof(EntityBase).IsAssignableFrom(t))
                   .Select(t => new
                   {
                       EntityType = t,
                       ConverterType = openType.MakeGenericType(t)
                   });
                foreach (var e in persistentEntties)
                {
                    var map = configuration.CreateMap(idType, e.EntityType);
                    map.ConvertUsing(e.ConverterType);
                }
         }
    }
                   
