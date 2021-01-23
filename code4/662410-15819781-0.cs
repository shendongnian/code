    [DataContract]
    [Serializable]
    public class myWSMethodResponse
    {
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string Report { get; set; }
    }
    public myWSMethodResponse myWSMethod(int parameterA)
    {
      //code here
    }
