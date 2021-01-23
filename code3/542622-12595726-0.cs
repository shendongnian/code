        public class Converter : ITypeConverter<Collection<OrderDetailDto>, Collection<OrderDetail>>
        {
            public Collection<OrderDetail> Convert(ResolutionContext context)
            {
                var destCollection = (Collection<OrderDetail>) context.DestinationValue;
                var sourceCollection = (Collection<OrderDetailDto>)context.SourceValue;
                foreach (var source in sourceCollection)
                {
                    var dest = destCollection.SingleOrDefault(d => d.MergeId == source.MergeId);
                    Mapper.Map(source, dest);
                }
                return destCollection;
            }
        }
