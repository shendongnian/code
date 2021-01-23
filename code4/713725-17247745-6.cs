    public class EntityLocale
    {
        public virtual string CultureName { get; set; }
        public virtual string Name { get; set; }
    }
    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            HasMany(x => x.Locales)
                .AsMap<string>("Locale")
                .Component(
                c => {
                    c.Map(x => x.CultureName).Formula("Locale").Not.Insert().Not.Update();
                    c.Map(x => x.Name);
                }
            );
        }
    }
