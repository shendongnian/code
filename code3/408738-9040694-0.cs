    public interface IInterfaceOne { void Hello(); } 
    public interface IInterfaceTwo { void World(); } 
     
    public class Implementation : IInterfaceOne, IInterfaceTwo
    {
       public void Hello() { };
       public void World() { };
    } 
     
    public class UsingImplementation 
    {
       private readonly IInterfaceOne one;
       private readonly IInterfaceTwo two;
       public UsingImplentation(IInterfaceOne one, IInterfaceTwo two)
       {
          this.one = one;
          this.two = two;
       }
       // do the stuff you want to do with an IInterfaceOne using field one
       public DoSomeThingWithOne() { one.Hello(); }
       // do the stuff you want to do with an IInterfaceTwo using field two
       public DoSomeThingWithTwo() { two.World(); }
    }
