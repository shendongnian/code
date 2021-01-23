    public class FactoryObjectB : IFactoryObjectB {
      public IConcreteObjectB Create(){
        return new ConcreteObjectB();
      }
    }
