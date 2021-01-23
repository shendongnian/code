    public class ContentTypeAttribute : Attribute
    {
        public string ContentType { get; set; }
        public ContentTypeAttribute(string contentType) 
        { 
             ContentType = contentType;
        }
    }
    public enum ReportFileGeneratorFileType
    {
        [ContentType("application/vnd.ms-excel")]
        Excel,
        [ContentType("application/pdf")]
        Pdf,
        [ContentType("application/vnd.ms-word")]
        Word
    }
