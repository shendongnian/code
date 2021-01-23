    [JsonObject(MemberSerialization.OptIn)] // this is important!
    public class UrlStats
    {
        public string URL { get; set; }
        public List<Stats> TotalPages { get; set; }
        public List<Stats> TotalTitles { get; set; }
        public List<Stats> DuplicateTitles { get; set; }
        public List<Stats> OverlengthTitles { get; set; }
        [JsonProperty] public int TotalPagesFound { get; set; }
        [JsonProperty] public int TotalTitleTags { get; set; }
        [JsonProperty] public int NoDuplicateTitleTags { get; set; }
        [JsonProperty] public int NoOverlengthTitleTags { get; set; }
    }
