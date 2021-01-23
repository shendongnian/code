    public interface ISpecification<T>
    {
       Expression<Func<T, bool>> SpecExpression { get; }
       bool IsSatisfiedBy(T obj);
    }
