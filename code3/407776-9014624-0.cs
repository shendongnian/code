    [DataContract]
    public class MyImage
    {
        [DataMember]
        public byte[] Image { get; set; }
        [DataMember]
        public string FullPath { get; set; }
    }
