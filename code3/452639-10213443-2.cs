    internal interface IContainer<out TIdentifier> where TIdentifier : IIdentifier 
    { 
        TIdentifier GetEntity(); 
    }
    internal interface IManager<out TIdentifier> where TIdentifier : IIdentifier 
    {
        IContainer<IIdentifier> Container { get; }
    }
    internal class SpecificEntityManager : IManager<ISpecificEntity>
    {
        public IContainer<IIdentifier> Container { get; set; }
    }
    internal class AnotherSpecificEntityManager : IManager<IAntoherSpecificEntity>
    {
        public IContainer<IIdentifier> Container { get; set; }
    }
