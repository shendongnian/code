    public static class MapExtensions
    {        
      
        public static void InheritMapping<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Action<InheritMappingExpresssion<TSource, TDestination>> action)
        {
            InheritMappingExpresssion<TSource, TDestination> x =
                new InheritMappingExpresssion<TSource, TDestination>(mappingExpression);
            action(x);
            x.ConditionsForAll();
        }
        private static bool NotAlreadyMapped(Type sourceType, Type desitnationType, ResolutionContext r, Type typeSourceCurrent, Type typeDestCurrent)
        {
            var result = !r.IsSourceValueNull &&
                   Mapper.FindTypeMapFor(sourceType, desitnationType).GetPropertyMaps().Where(
                       m => m.DestinationProperty.Name.Equals(r.MemberName)).Select(y => !y.IsMapped()
                       ).All(b => b);
            return result;
        }
        public class InheritMappingExpresssion<TSource, TDestination>
        {
            private readonly IMappingExpression<TSource, TDestination> _sourcExpression;
            public InheritMappingExpresssion(IMappingExpression<TSource, TDestination> sourcExpression)
            {
                _sourcExpression = sourcExpression;
            }
            public void IncludeSourceBase<TSourceBase>(
                bool ovverideExist = false)
            {
                Type sourceType = typeof (TSourceBase);
                Type destinationType = typeof (TDestination);
                if (!sourceType.IsAssignableFrom(typeof (TSource))) throw new NotSupportedException();
                Result(sourceType, destinationType);
            }
            public void IncludeDestinationBase<TDestinationBase>()
            {
                Type sourceType = typeof (TSource);
                Type destinationType = typeof (TDestinationBase);
                if (!destinationType.IsAssignableFrom(typeof (TDestination))) throw new NotSupportedException();
                Result(sourceType, destinationType);
            }
            public void IncludeBothBases<TSourceBase, TDestinatioBase>()
            {
                Type sourceType = typeof (TSourceBase);
                Type destinationType = typeof (TDestinatioBase);
                if (!sourceType.IsAssignableFrom(typeof (TSource))) throw new NotSupportedException();
                if (!destinationType.IsAssignableFrom(typeof (TDestination))) throw new NotSupportedException();
                Result(sourceType, destinationType);
            }
            internal void ConditionsForAll()
            {
                _sourcExpression.ForAllMembers(x => x.Condition(r => _conditions.All(c => c(r))));//указываем что все кондишены истинны
            }
            private List<Func<ResolutionContext, bool>> _conditions = new List<Func<ResolutionContext, bool>>();
            private void Result(Type typeSource, Type typeDest)
            {
                    _sourcExpression.BeforeMap((x, y) =>
                    {
                        Mapper.Map(x, y, typeSource, typeDest);
                    });
                    _conditions.Add((r) => NotAlreadyMapped(typeSource, typeDest, r, typeof (TSource), typeof (TDestination)));
            }
        }
        
    }
