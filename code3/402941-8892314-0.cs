    public interface IFactory{
      object Create();
    }
    
    public interface IFactoryThatHasProduct: IFactory
    {
      object GetProduct(int id);
    }
    
    public class MyCommand
    {
      //...
    }
    
    public class MyCommandFactory:IFactoryThatHasProduct
    {
      object Create(){
        return new MyCommand();
      }
     
      object GetProduct(int id){
        return //TODO
      }
    }
    
    public class Program
    {
      public Program(IFactory factory, int productId)
      {
        // consider just having the method take IFactoryThatHasProduct instead of IFactory
        if(factory is IFactoryThatHasProduct){
          var factoryThatHasProduct = (IFactoryThatHasProduct) factory;
          var product = factoryThatHasProduct.GetProduct(productId);
        }
        else{
          throw new Exception("Cannot pass in a factory that does not implement IFactoryThatHasProduct");
        }
      }
    }
}
