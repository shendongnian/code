    [Serializable]
    public class ResponseHead
    {        
        public bool result {get; set;}        
        public float time {get; set;}        
    }
    
    [Serializable]
    public class ResponseBody
    {        
        public List<string> body{get; set;}
    }
    
    [Serializable]
    public class ResponseObj
    {        
        public ResponseBody body {get; set;}        
        public ResponseHead head {get; set;}        
    }
