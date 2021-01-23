    public class MyViewModel
    { 
        [MaxFileSize(MAX_ALLOWED_SIZE)]
        public HttpPostedFileBase Document { get; set; }
    
        ... some other properties and stuff
    }
