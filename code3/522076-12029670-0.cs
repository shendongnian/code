    public class Category
    {
        public virtual IDictionary<Locale, string> Names { get; private set; }
        public virtual string Name { get { return Names[GetActiveLocaleFromSomewhere()]; } }
    }
    public CategoryMap()
    {
        HasMany(x => x.Names)
            .Table("CategoryLocale")
            .KeyColumn("CategoryId")
            .AsEntityMap("LocaleId")
            .Element("CategoryName")
    }
