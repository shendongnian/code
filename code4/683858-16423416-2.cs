    public class Agent
    {
        public ObjectId Id { get; set; }
        [BsonElement("Agent_name")]
        public AgentName Name { get; set; }
        [BsonElement("Agent_LoginSessionId")]
        public string LoginSessionId { get; set; }
        [BsonElement("Agent_GroupCode")]
        public string GroupCode { get; set; }
        [BsonElement("Agent_dtmCreated")]
        public string Created { get; set; }
        [BsonElement("Agent_dtmLastLogin")]
        public string LastLogin { get; set; }
        [BsonElement("Agent_strIsActive")]
        public string IsActive { get; set; }
        [BsonElement("stamps")]
        public Stamps Stamps { get; set; }
    }
    public class AgentName
    {
        [BsonElement("f")]
        public string First { get; set; }
        [BsonElement("l")]
        public string Last { get; set; }
    }
    public class Stamps
    {
        [BsonElement("ins")]
        public string Inserted { get; set; }
        [BsonElement("upd")]
        public string Updated { get; set; }
        [BsonElement("createUsr")]
        public string CreateUser { get; set; }
        [BsonElement("updUser")]
        public string UpdateUser { get; set; }
        [BsonElement("Ins_Ip")]
        public string InsertIPAddress { get; set; }
        [BsonElement("Upd_Ip")]
        public string UpdateIPAddress { get; set; }
    }
