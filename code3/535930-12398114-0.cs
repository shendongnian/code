    [JsonObject(MemberSerialization.OptIn)]
    public class AppointmentList
    {
        [JsonProperty(PropertyName="data")]
        public List<Calendar> data {get; set;}
    }
