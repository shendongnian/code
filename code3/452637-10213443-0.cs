    class Program
    {
        static void Main(string[] args)
        {
            IManager<IIdentifier> f1 = new C1();
            IManager<IIdentifier> f2 = new SpecificEntityManager(); //IManager<ISpecificEntity>
        }
    }
    interface IIdentifier { }
    interface ISpecificEntity : IIdentifier { }
    interface IManager<out T> { }
    class C1 : IManager<IIdentifier> { }
    class SpecificEntityManager : IManager<ISpecificEntity> { }
