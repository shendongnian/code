    public class FileAssistant
    {
        public FileAssistant() { }
        public FileAssistant(string itemNo, string fileName)
        {
            ItemNo = itemNo;
            FileName = fileName;
        }
        public string ItemNo { get; set; }
        public string FileName { get; set; }
    }
