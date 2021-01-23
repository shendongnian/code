    [Validator(typeof(ServicesViewModelValidator))]
    public class ServicesViewModel
    {
         public int? ComponentTypeId { get; set; }
    
         public IEnumerable<ComponentType> ComponentTypes { get; set; }
    
         public int DomainId { get; set; }
    
         public IEnumerable<Domain> Domains { get; set; }
    }
