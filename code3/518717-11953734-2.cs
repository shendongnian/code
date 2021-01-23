    [JsonObject(MemberSerialization.OptOut)] // this is default and can be omitted
    public class UrlStats
    {
        [JsonIgnore] public string URL { get; set; }
        [JsonIgnore] public List<Stats> TotalPages { get; set; }
        [JsonIgnore] public List<Stats> TotalTitles { get; set; }
        [JsonIgnore] public List<Stats> DuplicateTitles { get; set; }
        [JsonIgnore] public List<Stats> OverlengthTitles { get; set; }
        public int TotalPagesFound { get; set; }
        public int TotalTitleTags { get; set; }
        public int NoDuplicateTitleTags { get; set; }
        public int NoOverlengthTitleTags { get; set; }
    }
