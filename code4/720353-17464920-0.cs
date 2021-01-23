    [XmlRoot("SIT_ENTRY_LIST")]
    public class SitEntryList
    {
        [XmlElement("SIT_ENTRY", IsNullable = true)]
        public List<SitEntry> EntryList { get; set; }
    }
    [...]
    var sitentrylist = new SitEntryList
    {
        EntryList = new List<SitEntry>
        {
            new SitEntry
            {
                EntryId = "Entry1"
            },
            new SitEntry
            {
                EntryId = "Entry2"
            }
        }
    };
    s = SerializeToString(sitentrylist);
