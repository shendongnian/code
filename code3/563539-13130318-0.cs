    public interface IExporterFactory
    {
        IExporter Create(SomeDataStructure someData);
    }
    
    public abstract class ExporterFactoryBase : IExporterFactory
    {
         protected ExporterFactoryBase(IExportDataProvider provider)
         {
              if (provider == null) throw new ArgumentNullException();
    
              Provider = provider;
         }
    
         public IExportDataProvider Provider { get; private set; }
    
         public abstract IExporter Create(SomeDataStructure someData);
    }
    
    public class MyConcreteExporterFactory : ExporterFactoryBase
    {
         public MyConcreteExporterFactory(IExportDataProvider provider)
            : base(provider)
         {
         }      
    
         public IExporter Create(SomeDataStructure someData)
         {
             var data = Provider.Load(someData.Id);
    
             // do whatever. for example...
             return new MyConcreteExporter(data);
         }
    }
