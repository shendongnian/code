    public class DomainTypeConverter : TypeConverter<DomainClass, DomainViewModel>
    {
        protected override DomainViewModel ConvertCore(DomainClass source)
        {
            return Mapper.Map<NestedDomainClass2, DomainViewModel>
                                 (source.NestedDomainClass1.NestedDomainClass2);
        }
    }
