    public class ImageGalleryFolderViewModel
    {
        [Required]
        public string Title { get; set; }
    
        public int Id { get; set; }
        public string CoverImageFileName { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
        public int ParentFolderId { get; set; }
        public IList<ImageGalleryFolder> AllFolders { get; set; } 
    }
