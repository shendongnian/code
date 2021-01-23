    public ActionResult GenerateImage() {
        FileContentResult result;
        using(var memStream = new System.IO.MemoryStream()) {
            bitmap.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            result = this.File(memStream.GetBuffer(), "image/jpeg");
        }
        return result;
    }
