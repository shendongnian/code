    public class MyViewModel
    {
        [FileExtensions("txt|doc", MaxContentLength = 200000)]
        public HttpPostedFileBase File { get; set; }
    }
