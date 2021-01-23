    [DataContract]
    [KnownType(typeof(DtoParameterDoubleCalculatedValue))]
    [KnownType(typeof(DtoParameterXXXCalculatedValue))]
    public DtoParameterCalculatedValueBase 
    {
      ...whatever common part there may be or nth...
    }
    
    public DtoParameterDoubleCalculatedValue : DtoParameterCalculatedValueBase 
    {
      [DataMember]
      public double Value {get;set;}
    }
    
    public DtoParameterXXXCalculatedValue : DtoParameterCalculatedValueBase 
    {
      [DataMember]
      public XXX Value {get;set;}
    }
