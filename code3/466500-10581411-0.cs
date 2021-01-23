    namespace Rest
    {
        public class JsonRes
        {
            public ResponseList ResponseList { get; set; }
            public ResStatus ResponseStatus { get; set; }
    
        }
        public class ResponseList
        {
            public string triName { get; set; }
            public string name { get; set; }
        }
        public class ResStatus
        {
            public string status { get; set; }
            public string message { get; set; }
        }
    
    }
