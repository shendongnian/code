       public static class AutoFixtureExtensions
        {
            public static void FreezeActivator<T>(this IFixture fixture, object parameters)
            {
                var builder = new CustomConstructorBuilder<T>();
                foreach (var prop in parameters.GetType().GetProperties())
                {
                    builder.Addparameter(prop.Name, prop.GetValue(parameters));
                }
     
                fixture.Customize<T>(x => builder);
            }
        }
