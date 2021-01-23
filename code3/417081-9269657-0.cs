    public FileResult ShowCroppedImage(int id, int size)
    {
        string path = "~/Uploads/Photos/";
        string sourceFile = Server.MapPath(path) + id + ".jpg";
        using (MemoryStream stream = new MemoryStream())
        {
            using (Bitmap bitmap = imageManipulation.CropImage(sourceFile, size, size))
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] bytes = stream.ToArray();
                return File(bytes, "image/png");
            }
        }
    }
