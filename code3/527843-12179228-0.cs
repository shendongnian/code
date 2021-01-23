    namespace Model.Entities {
    
        [MetadataType(typeof(FieldMetadata))]
        public partial class Field : EntityBase {
    
        }
    
        class FieldMetadata {
            [Required]
            public object Value;
        }
    }
