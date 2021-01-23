    public class FileDetail
    {
        [DisplayName("File Name")]    
        public  string filename { get; set; }
        [DisplayName("Open Connection")]    
        public int openConnectionCount { get; set; }
        [DisplayName("close Connection")]    
        public int closeConnectionCount { get; set; }
    }
