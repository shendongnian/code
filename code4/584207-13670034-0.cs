    [DataContract(Name = "DbResponse{0}"]
    public class DbResponse<T>
    {
        [DataMember]
        public DbStatus Status { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public T Data { get; set; }
    }
