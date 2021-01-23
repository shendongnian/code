    interface IDataLayer { ... }
    interface IDataLayerFactory 
    {
       IDataLayer Create();
    }    
    public class BLLayer()
    {
       // You can use the setter to inject your mock
       public IDataLayerFactory Factory { get; set; }
       public BLLayer()
       {
         Factory = new RealFactoryImpl();  // set the real implementation as default
       }
    
       public GetBLObject(string params)
       {
         using(DLayer dl = Factory.Create())  // replace the "new"
         {  
           //BL logic here....    
         }
       }
    }
