    public class APIResponse
    {
        public APIContent Content { get; set; }
        public string Status { get; set; }
    }
    public class APIContent
    {
        public string CallID { get; set; }
        public APIDetail Detail { get; set; }
        public APICallService CallService { get; set; }
    }
