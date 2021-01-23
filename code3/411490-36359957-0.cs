    [CollectionDataContract(Name = "AdditionalProperties",
                                ItemName = "Property",
                                KeyName = "Key",
                                ValueName = "Value")]
    public class AdditionalProperties : Dictionary<string, string>
    {
    }
