    [MetadataType(typeof(MyModelMetadata))]
    public class MyModel : MyModelBase {
      ... /* the current model code */
    }
    
    [DataContract]
    public class MyModelMetadata {
        [DataMember] 
        public string Name { get; set; }
    }
