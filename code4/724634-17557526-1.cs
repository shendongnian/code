    public class UploadResult
    {
        public UploadResult()
        {
            InvalidField =  new List<CSVModel>();
            Valid =  new List<CSVModel>();
        }
        public List<CSVModel> InvalidField;
        public List<CSVModel> Valid;
    }
