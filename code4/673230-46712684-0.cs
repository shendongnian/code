    public class Proveedores {
    
    }
    
    [CollectionDataContract(Name = "Proveedores", ItemName = "Proveedore", Namespace = "")]
    public class ProveedoresList : List<Proveedores> {
    
    }
    public class MakeThis {
        [DataMember(Name = "Proveedores", Order = 0)]
        public ProveedoresList Pros { get; private set; }
    }
