    [MetadataType(typeof(MyModelMetadata))]
    public class MyModel : MyModelBase {
      ... /* the current model code */
    }
    
    
    internal class MyModelMetadata {
        [Required]
        public string Name { get; set; }
    }
