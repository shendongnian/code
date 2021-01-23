     public JsonResult GetImageDetails(int ID)
     {
         var img = Image.FromFile(<path to image on server>);
         return Json(new { width = img.Width, height = img.Height });
     }
