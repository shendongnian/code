     Response.ContentType = "text/plain";
     string c = Request.Form["image_data"];
     string FileName = Request.Form["FileName"];
     byte[] bytes = Convert.FromBase64String(c);
     
     System.Drawing.Image image;
     using (MemoryStream ms = new MemoryStream(bytes))
     {
          image = System.Drawing.Image.FromStream(ms);
          image.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
          String Fname =   FileName + ".jpeg";
          image.Save(Server.MapPath("Image\\" + Fname), System.Drawing.Imaging.ImageFormat.Jpeg);
          Response.End();
     }
