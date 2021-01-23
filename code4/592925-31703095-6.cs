    //on your view model
    public class MyViewModel
        {
            [Required]
            [DisplayName("Select File to Upload")]
            public IEnumerable<HttpPostedFileBase> File { get; set; }
        }
    // on your object class, make sure you have a data type byte[] that will store a file in a form of bytes, a byte[] data type store both Images and documents of any content type. 
        public class FileUploadDBModel
        {
            [Key]
            public int Id { get; set; }
            public string FileName { get; set; }
            public byte[] File { get; set; }
        }
    // on your view 
    <div class="jumbotron">
        @using (Html.BeginForm(null, null, FormMethod.Post, new { enctype = "multipart/form-data" }))
        {
            <div>
                @Html.LabelFor(x => x.File)
                @Html.TextBoxFor(x => x.File, new { type = "file" })
                @Html.ValidationMessageFor(x => x.File)
            </div>
            <button type="submit">Upload File</button>
        }
    </div>
     
    
    //on your controller
     public ActionResult Index(MyViewModel model)
            {
                    FileUploadDBModel fileUploadModel = new FileUploadDBModel();
                    //uploading multiple files in the database
                    foreach (var item in model.File)
                    {
                        byte[] uploadFile = new byte[item.InputStream.Length];
                        item.InputStream.Read(uploadFile, 0, uploadFile.Length);
    
                        fileUploadModel.FileName = item.FileName;
                        fileUploadModel.File = uploadFile;
    
                        db.FileUploadDBModels.Add(fileUploadModel);
                        db.SaveChanges();
                    }
                }
    
     
 
