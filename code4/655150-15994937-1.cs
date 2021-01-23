    using FluentNHibernate.Mapping;
    
    namespace Core.Mapping
    {
        public class CountryTranslationMap : ClassMap<CountryTranslation>
        {
            public CountryTranslationMap()
            {
                Id(x => x.Id);
    
                Version(x => x.LastModified);
    
                Map(x => x.Culture)
                    .Length(2)
                    .Not.Nullable();
    
                Map(x => x.Name)
                    .Length(50)
                    .Not.Nullable();
    
                References(x => x.Country);
            }
        }
