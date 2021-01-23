    public override void ExecuteResult(ControllerContext context)
    {
        using (Bitmap bitmap = new Bitmap(_imageBitmap))
        {
                context.HttpContext.Response.ContentType = "image/jpg";
                bitmap.Save(context.HttpContext.Response.OutputStream, ImageFormat.Jpeg);
        }
    }
