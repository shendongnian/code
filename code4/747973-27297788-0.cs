    public class CompanyModel
    {
        [Display(Name = "Logo")]
        [File(AllowedFileExtensions = new string[] { ".jpg", ".gif", ".tiff", ".png" }, MaxContentLength = 1024 * 1024 * 30, ErrorMessage = "Invalid File")]
        public HttpPostedFileBase LogoFileUp{ get; set; }
        
        //you can add other properties if you like, for example companyname
    }
