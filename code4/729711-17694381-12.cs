    [DataContract]
    public class AjaxResult
    {
        public static AjaxResult GetSuccessResult()
        {
            return new AjaxResult();
        }
    
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Error { get; set; }
    }
