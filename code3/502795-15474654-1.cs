      string filePath = "~/Files/";
            //write your handler implementation here.
            if (context.Request.Files.Count <= 0)
            {
                context.Response.Write("No file uploaded");
            }
            else
            {
                for (int i = 0; i < context.Request.Files.Count; ++i)
                {
                    HttpPostedFile file = context.Request.Files[i];
                     var fileInfo = new FileInfo(file.FileName);
                    file.SaveAs(context.Server.MapPath(filePath + fileInfo.Name));
                    context.Response.Write("File uploaded");
                }
            }
