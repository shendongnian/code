    public interface IFileUploadModel
    {
        // any common properties would go here
    }
    public abstract class FileUploadModel : IFileUploadModel
    {
        // implement the common stuff
    }
    public class CreateBrandViewModel : FileUploadModel
    {
        [PermittedFileExtensions("jpg, jpeg, png, gif")]
        [MaxFileSize("2MB")]
        [UIHint("MultiImageUploader")]
        public HttpPostedFileBase Image { get; set; }
    }
    public class SomeOtherUploadModel : FileUploadModel
    {
        // Other special stuff here
    }
