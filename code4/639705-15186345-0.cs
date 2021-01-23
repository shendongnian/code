    interface IEntity<T>
    {
        T Value { get; }
    }
    class Car : IEntity<ICar>
    {
        ICar Value { get; }
    }
    class Person : IEntity<IPerson>
    {
        IPerson Value { get; }
    }
