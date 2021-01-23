    public interface ISpecification<TEntity> where TEntity : class, IAggregate
        {
            bool IsSatisfiedBy(TEntity entity);
        }
    internal class AndSpecification<TEntity> : ISpecification<TEntity> where TEntity: class, IAggregate
        {
            private ISpecification<TEntity> Spec1;
            private ISpecification<TEntity> Spec2;
    
            internal AndSpecification(ISpecification<TEntity> s1, ISpecification<TEntity> s2)
            {
                Spec1 = s1;
                Spec2 = s2;
            }
    
            public bool IsSatisfiedBy(TEntity candidate)
            {
                return Spec1.IsSatisfiedBy(candidate) && Spec2.IsSatisfiedBy(candidate);
            }
    
            
        }
    
        internal class OrSpecification<TEntity> : ISpecification<TEntity> where TEntity : class, IAggregate
        {
            private ISpecification<TEntity> Spec1;
            private ISpecification<TEntity> Spec2;
    
            internal OrSpecification(ISpecification<TEntity> s1, ISpecification<TEntity> s2)
            {
                Spec1 = s1;
                Spec2 = s2;
            }
    
            public bool IsSatisfiedBy(TEntity candidate)
            {
                return Spec1.IsSatisfiedBy(candidate) || Spec2.IsSatisfiedBy(candidate);
            }
        }
    
        internal class NotSpecification<TEntity> : ISpecification<TEntity> where TEntity : class, IAggregate
        {
            private ISpecification<TEntity> Wrapped;
    
            internal NotSpecification(ISpecification<TEntity> x)
            {
                Wrapped = x;
            }
    
            public bool IsSatisfiedBy(TEntity candidate)
            {
                return !Wrapped.IsSatisfiedBy(candidate);
            }
        }
    
        public static class SpecsExtensionMethods
        {
            public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> s1, ISpecification<TEntity> s2) where TEntity : class, IAggregate
            {
                return new AndSpecification<TEntity>(s1, s2);
            }
    
            public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> s1, ISpecification<TEntity> s2) where TEntity : class, IAggregate
            {
                return new OrSpecification<TEntity>(s1, s2);
            }
    
            public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> s) where TEntity : class, IAggregate
            {
                return new NotSpecification<TEntity>(s);
            }
        }
