    [DataContract] //< I forgot how serialization on the phone works, please forgive me if the tags differ
    struct Metadata
    {
         [DataMember]
         public int Length;
         [DataMember]
         public int NumBlocksDownloaded;
    }
