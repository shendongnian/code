    public class CreateViewModel : UnitViewModel 
    {
        [Required(ErrorMessage = "Required field")] 
        [FileAttribute(AllowedFileExtensions = new string [] { ".xls", ".xlsx" })]
        public HttpPostedFileBase CommonFile { get; set; }
    }
