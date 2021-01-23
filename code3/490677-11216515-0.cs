    public class MyController : Controller
    {
        public FileContentResult GetImage(int id)
        {
            Image myimage = Bitmap.FromFile(Server.MapPath("~/Images/myimage.jpg"));
            var format = System.Drawing.Imaging.ImageFormat.Jpeg;
            string mimeType = "jpeg";
    
            MemoryStream ms = new MemoryStream();
            myimage.Save(ms, format);
    
            return File(ms.ToArray(), "images/" + mimeType);
        }
    }
