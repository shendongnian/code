        [DataContract(Name = "Proveedore", Namespace = "")]
        public class Proveedores {
        
        }
        
        [CollectionDataContract(Name = "ArrayOfProveedores", ItemName = "Proveedore", Namespace = "")]
        public class ProveedoresList : List<Proveedores> {
        
        }
        public class FileRead{
            [DataMember(Name = "ArrayOfProveedores", Order = 0)]
            public ProveedoresList Pros { get; private set; }
        }
