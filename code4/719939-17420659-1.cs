    public class MessageResponse
    {
        public string isData { get; set; }
        public Details Details { get; set; }
    } 
    
    public class Details
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string FileFormat { get; set; }
        public string FileType { get; set; }
        public string FileDuration { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string File { get; set; }
    }
