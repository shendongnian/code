    // Example of usage
    Mapper.CreateMap<UserModel, User>();
    var converter = CollectionConverterWithIdentityMatching<UserModel, User>.Instance(model => model.Id, user => user.Id);
    Mapper.CreateMap<List<UserModel>, List<User>>().ConvertUsing(converter);
    //The actual converter
    public class CollectionConverterWithIdentityMatching<TSource, TDestination> : 
        ITypeConverter<List<TSource>, List<TDestination>> where TDestination : class
    {
        private readonly Func<TSource, object> sourcePrimaryKeyExpression;
        private readonly Func<TDestination, object> destinationPrimaryKeyExpression;
    
        private CollectionConverterWithIdentityMatching(Expression<Func<TSource, object>> sourcePrimaryKey, Expression<Func<TDestination, object>> destinationPrimaryKey)
        {
            this.sourcePrimaryKeyExpression = sourcePrimaryKey.Compile();
            this.destinationPrimaryKeyExpression = destinationPrimaryKey.Compile();
        }
    
        public static CollectionConverterWithIdentityMatching<TSource, TDestination> 
            Instance(Expression<Func<TSource, object>> sourcePrimaryKey, Expression<Func<TDestination, object>> destinationPrimaryKey)
        {
            return new CollectionConverterWithIdentityMatching<TSource, TDestination>(
                sourcePrimaryKey, destinationPrimaryKey);
        }
    
        public List<TDestination> Convert(ResolutionContext context)
        {
            var destinationCollection = (List<TDestination>)context.DestinationValue ?? new List<TDestination>();
            var sourceCollection = (List<TSource>)context.SourceValue;
            foreach (var source in sourceCollection)
            {
                TDestination matchedDestination = default(TDestination);
                        
                foreach (var destination in destinationCollection)
                {
                    var sourcePrimaryKey = GetPrimaryKey(source, this.sourcePrimaryKeyExpression);
                    var destinationPrimaryKey = GetPrimaryKey(destination, this.destinationPrimaryKeyExpression);
                            
                    if (string.Equals(sourcePrimaryKey, destinationPrimaryKey, StringComparison.OrdinalIgnoreCase))
                    {
                        Mapper.Map(source, destination);
                        matchedDestination = destination;
                        break;
                    }
                }
    
                if (matchedDestination == null)
                {
                    destinationCollection.Add(Mapper.Map<TDestination>(source));
                }
            }
    
            return destinationCollection;
        }
    
        private string GetPrimaryKey<TObject>(object entity, Func<TObject, object> expression)
        {
            var tempId = expression.Invoke((TObject)entity);
            var id = System.Convert.ToString(tempId);
            return id;
        }
    }
    
