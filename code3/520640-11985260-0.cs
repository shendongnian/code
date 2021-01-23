    public class CreateBrandViewModel
    {
        [PermittedFileExtensions("jpg, jpeg, png, gif")]
        [MaxFileSize("2MB")]
        [UIHint("MultiImageUploader")]
        public HttpPostedFileBase Image { get; set; }
    }
