    [DataContractAttribute]
    public class MusicFileDict
    {
        [DataMember]
        public Uri MusicFileUri { get; set; }
    
        [DataMember]
        public int Id { get; set; }
    }
