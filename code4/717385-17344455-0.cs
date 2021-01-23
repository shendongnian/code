    [DataContract]
    public sealed class MyJson
    {
        [DataMember(Name="FormTitle", IsRequired = true)]
        public string FormTitle { get; set; }
        
        ...
        [DataMember(Name="FormBody", IsRequired = true)]
        public FormBody fb { get; set; }
    }
    [DataContract]
    public sealed class FormBody
    {
        [DataMember(Name="image", IsRequired = true)]
        public Image img { get; set; }
        
        ...
    }
