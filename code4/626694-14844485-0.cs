    public class ImageViewModel
    {
        public string FileName { get; set; }
    
        public string MIME { get; set; }
    
        public byte[] Data { get; set; }
    
        public override string ToString()
        {
            return string.Format(@"data:{0};base64,{1}", MIME.ToLower(), Convert.ToBase64String(Data));
        }
    }
