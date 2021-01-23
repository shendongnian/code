    [DataContract]
    public class MyResource
    {
        [DataMember]
        public string Data { get; set; }
    
        public ReturnCode Code { get; set; }
    
        [DataMember(Name = "returnCode")]
        string ReturnCodeString
        {
            get { return this.Code.ToString(); }
            set
            {
                ReturnCode r;
                this.Code = Enum.TryParse(value, true, out r) ? r : ReturnCode.OK;
            }
        }
    }
