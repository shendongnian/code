    public class MyClass1
    {
        protected virtual IDictionary<string, string> Names { get; private set; }
        public virtual string Name { get { return Names[GetCurrentLanguageFromSomeWhere()]; } }
    }
    public class MyClass1Map : ClassMap<MyClass1>
    {
        public MyClass1Map()
        {
            [...]
            HasMany(mc => mc.Names)
                .Table("Translations")
                .Where("property == 'Name'")
                .AsMap("language")
                .Element("text")
                .Not.LazyLoad();
    
            HasMany(mc => mc.Descriptions)
                .Table("Translations")
                .Where("property == 'Description'")
                .AsMap("language")
                .Element("text")
                .Not.LazyLoad();
        }
    }
