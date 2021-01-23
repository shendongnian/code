    public class PropertyServiceFactory{
      private readonly IPropertyRepository _repository;
      public PropertyServiceFactory(IPropertyRepository repository){
        _repository = repository
      }
      public IPropertyService Create(){
        PropertyService service = new PropertyService(_repository);
        return service; 
      }
    }
