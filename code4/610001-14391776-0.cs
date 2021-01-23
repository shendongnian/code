    [DataContract(Name = "CarCondition")]
    public enum CarConditionWithDifferentNames
    {
        [EnumMember(Value = "New")]
        BrandNew,
        [EnumMember(Value = "Used")]
        PreviouslyOwned,
        [EnumMember]
        Rental
    }
