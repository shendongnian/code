    [DataContract]
    public class GetStuffParams
    {
        [DataMember]
        string beep {get; set; }
        
        [DataMember]
        string boop  {get; set;}
        public GetStuffParams() { boop = "too lazy to type"; }
    }
    [OperationContract]
    [WebGet]
    String GetStuff(GetStuffParams stuffParams);
