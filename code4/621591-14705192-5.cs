    public static class Extensions
    {
        public static IMappingExpression<Source, TDestination> MapBase<TDestination>(
            this IMappingExpression<Source, TDestination> mapping)
            where TDestination: DestinationBase
        {
            // all base class mappings goes here
            return mapping.ForMember(d => d.Test3, e => e.MapFrom(s => s.Test));
        }
    }
