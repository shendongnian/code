    [DataContract]
    public class User : ICloneable  
    {
        [DataMember(Name = "login")]
        [JsonProperty(PropertyName = "login")]
        [StringLength(40, ErrorMessage = "The Login value cannot exceed 40 characters. ")]
        [DefaultValue("")]
        public String Login { get; set; }
        [DataMember(Name = "id")]
        [JsonProperty(PropertyName = "id")]
        public int UserId { get; set; }
    }
