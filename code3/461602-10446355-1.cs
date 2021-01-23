    public class MyViewModel
    {
        [Required]
        [MaxFileSize(8 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} bytes")]
        public HttpPostedFileBase File { get; set; }
    }
