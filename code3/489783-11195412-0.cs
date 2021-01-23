    @using (Html.BeginForm("Index", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
      <input id="file" type="file" name="file" />
      <input type="submit" value="Upload" class="btn" />
    }
     public ActionResult ChangePhoto(HttpPostedFileBase file)
    {
        if (file != null && file.ContentLength > 0)
        {
          using (System.Drawing.Image Img = System.Drawing.Image.FromStream(file.InputStream))
          {
             Img.Save(Server.MapPath("~") +"/myimage.png", Img.RawFormat);
          }
     }
