    using FluentNHibernate.Mapping;
    namespace Core.Mapping
    {    
        public class CountryMap : ClassMap<Country>
        {
            public CountryMap()
            {
                Id(x => x.Id);
    
                Map(x => x.IsoCode)
                    .Length(2)
                    .Not.Nullable();
    
                HasMany(x => x.Translations)
                    .Fetch.Join()
                    .Not.LazyLoad()
                    .Cascade.AllDeleteOrphan();
            }
        }
    }
