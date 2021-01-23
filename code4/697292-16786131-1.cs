    public class EmployeePhotoViewModel 
    {
        public string Id { get; set; }
    
        [ValidateImage]
        public HttpPostedFileBase File { get; set; }
    }
