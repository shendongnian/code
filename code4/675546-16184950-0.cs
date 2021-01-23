    public class ConcreteObjectA : IConcreteObjectA{
      public ConcreteObjectA(IFactoryObjectB factoryB){
        factoryB.Create();
      }
    }
