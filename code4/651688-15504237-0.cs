    [DataContract]
    [KnownType(typeof(GetBarsByFooIdRequest))]
    [KnownType(typeof(GetBarsByMooIdRequest))]
    abstract class GetBarsRequest
    {
       ..
    }
    [DataContract]
    sealed class GetBarsByFooIdRequest : GetBarsRequest
    {
       [DataMember]
       public int FooID { get; set; }
    }
    sealed class GetBarsByMooIdRequest : GetBarsRequest
    {
       [DataMember]
       public int MooID { get; set; }
    }
    GetBarsResponse GetBars(GetBarsRequest);
