    public class PropertyServiceFactory{
      public IPropertyService Create(){
        IPropertyRepository repository = new PropertyRepository();
        PropertyService service = new PropertyService(repository);
        return service; 
      }
    }
