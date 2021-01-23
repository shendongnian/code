    public class MyViewModel
    {
        [NotMapped, ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]
        public HttpPostedFileBase File { get; set; }
    }
