    Mapper.CreateMap<NestedModel, NestedEntity>();
    Mapper.CreateMap<Model, Entity>()
          .ForMember(x => x.Nested, opt => opt.ResolveUsing<Resolver>());
    public class Resolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            var targetCollection = ((Entity) source.Context.DestinationValue).Nested;
            // TODO: Custom mapping here.
            return source.New(targetCollection, typeof(NestedEntity[]));
        }
    }
