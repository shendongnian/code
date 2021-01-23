      private Boolean ImageUploadValidation(FileUpload UploadedFile)
    {
        String FileExtension = String.Empty, Code = String.Empty;
        try
        {
            if (String.IsNullOrEmpty(UploadedFile.PostedFile.FileName))
            {
                Code = "<script> alert(' Please select file');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "someKey", Code);
                return false;
            }
            FileExtension = Path.GetExtension(UploadedFile.FileName).ToLower();
            if (!FileExtension.Equals(".gif") &&
                !FileExtension.Equals(".png") &&
                !FileExtension.Equals(".jpg") &&
                !FileExtension.Equals(".bmp") &&
                !FileExtension.Equals(".gif") &&
                !FileExtension.Equals(".jpeg") &&
                !FileExtension.Equals(".tif") &&
                !FileExtension.Equals(".tiff"))
            {
                Code = "<script> alert(' Please select valid file. File can be of extension(gif, png, jpg, bmp, gif, jpeg, tif, tiff)');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "someKey", Code);
                return false;
            }
            return true;
        }
        catch (Exception)
        {
            throw;
        }
