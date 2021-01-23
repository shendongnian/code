    [DataContract]
    public class WhereItsAt
    {
        [DataMember] public float Latitude { get; set; }
        [DataMember] public float Longitude { get; set; }
        [DataMember] public string Category { get; set; }
        [DataMember] public string SearchTerms { get{return "hello"}; set; }
        [DataMember] public float Distance { get; set; }
    }
