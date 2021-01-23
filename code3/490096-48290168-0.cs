    public class GenericClass
    {
        public virtual string ID {get;set;}
    }
    public class FaceBook : GenericClass
    {
        [JsonProperty("id")]
        public override string ID { get => base.ID; set => base.ID = value; }
    }
    public class Twitter : GenericClass
    {
        [JsonProperty("id_str")]
        public override string ID { get => base.ID; set => base.ID = value; }
    }
