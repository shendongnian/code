    [DataContract]
    public DtoRequestedCalculations
    {
      [DataMember]
      public long AtmId {get;set;}
    
      [DataMember]
      public List<DtoRequestedCalculationEntry> Calculations {get;set;}
    }
    
    [DataContract]
    public DtoRequestedCalculationEntry
    {
      [DataMember]
      public string / long / Guid / XXX ParameterIdentifier {get;set;}
    
      [DataMember]
      public double/ DtoParameterCalculatedValueBase {get;set;}
    }
