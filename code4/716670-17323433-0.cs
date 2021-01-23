    [DataContract(Name = "SimulationExceptionStatusCode")]
    public enum SimulationExceptionStatusCode
    {
        [EnumMember]
        SimulationInstanceNotExist,
        [EnumMember]
        LocationNotExist,
        [EnumMember]
        InvalidOperation,
        [EnumMember]
        GeneralError
    }
