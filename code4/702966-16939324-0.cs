    [DataContract(Name = "Validation")]
    public class FieldValidationModel
    {
          [DataMember]
          public string Annotation { get; set; }
          [DataMember]
          public PlanTypeCollection PlanTypes { get; set; }
    }
    [CollectionDataContract(ItemName="PlanType")]
    public class PlanTypeCollection : Collection<string>  {}
