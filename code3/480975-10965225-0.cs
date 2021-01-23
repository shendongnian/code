    throw new FaultException<InvalidArgumentException>(new InvalidArgumentException(),Constants.MaxLengthFields.PhoneNumber)), Response.OrderIdMissing);
    
    [DataContract, Serializable]
    enum Response
    {
     [EnumMember]
     OrderIdMissing,
     [EnumMember]
     ProductCodeInvalid,
    }
