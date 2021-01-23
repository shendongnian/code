    public static Byte[] ReadStream(Stream input)
    {
        Byte[] buffer = new Byte[(16 * 1024)];
        using (MemoryStream stream = new MemoryStream())
        {
            Int32 read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                stream.Write(buffer, 0, read);
            return stream.ToArray();
        }
    }
    protected void bn_upload_Click(object sender, EventArgs e)
    {
        lbl_msg.Text = "";
        Byte[] bytes = ReadStream(FileUpload1.PostedFile.InputStream);
        String src = byteArrayToImage(bytes);
        if (!src.Equals(""))
            Image1.ImageUrl = "~/Temp/UploadedImage.jpg";
    }
