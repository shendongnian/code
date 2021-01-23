    [DataContract("SIT_ENTRY")]
    public class SitEntry
    {
        [DataMember("STR_ENTRY_ID")]
        public string EntryId { get; set; }
    }
    [DataContract("SIT_ENTRY_LIST")]
    public class SitEntryList : List<SitEntry>
    {
    }
    using (MemoryStream requestObjectStream = new MemoryStream())
    {   
        DataContractSerializer serializer = new DataContractSerializer(typeof(SitEntry));
        serializer.WriteObject(requestObjectStream, objectToSerialize);
    }
