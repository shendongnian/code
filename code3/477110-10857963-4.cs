    interface IDataLayer { ... }
    interface IDataLayerFactory 
    {
       IDataLayer Create();
    }    
    public class BLLayer()
    {
      private IDataLayerFactory _factory;
       // present a default constructor for your average consumer
      ctor() : this(new RealFactoryImpl()) {} 
    
      // but also expose an injectable constructor for tests
      ctor(IDataLayerFactory factory)
      { 
        _factory = factory;
      }  
    
      public GetBLObject(string params)
      {
        using(DLayer dl = _factory.Create())  // replace the "new"
        {  
          //BL logic here....    
        }
      }
    }
