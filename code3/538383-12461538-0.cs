    using (MemoryStream ms = new MemoryStream())
    {
        captchaImage.RenderImage().Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        byte[] byteArray = ms.ToArray();
        context.Response.BinaryWrite(byteArray);
    }
