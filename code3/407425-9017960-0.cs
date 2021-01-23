    public class MyConventions : UnityContainerExtension
    {
        protected override void Initialize()
        {
            var dependers = from t in typeof(IThing).Assembly.GetExportedTypes()
                            where t.Name.StartsWith("Depender")
                            select t;
            foreach (var t in dependers)
            {
                var number = t.Name.TrimStart("Depender".ToArray());
                var realName = "Real" + number;
                var decoName = "Deco" + number;
                var config = "Config" + number;
                this.Container.RegisterType<IThing, RealThing>(realName, 
                    new InjectionConstructor(config));
                this.Container.RegisterType<IThing, DecoratingThing>(decoName,
                    new InjectionConstructor(
                        new ResolvedParameter<IThing>(realName)));
                this.Container.RegisterType(t,
                    new InjectionConstructor(
                        new ResolvedParameter<IThing>(decoName)));
            }
        }
    }
