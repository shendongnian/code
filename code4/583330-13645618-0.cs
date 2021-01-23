    [MetadataType(typeof(Metadata))]
    public class DerivedEntity : PocoEntity
    {
       private sealed class Metadata
       {
          [Required, AnotherAnnotation]
          public object NameOfPropertyToDecorate;
       }
    }
