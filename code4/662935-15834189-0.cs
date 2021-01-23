    string path1 = Server.MapPath("");
    path1.Replace("Application1", "Myapplication"); //Considering "Application1" is the name of your current application
    path1 += "/Images/Landing/bottom_banner/";
    HttpPostedFileBase photo = Request.Files["adup"];
            if (photo.ContentLength != 0)
            {
                string lastPart = photo.FileName.Split('\\').Last();
                Random random = new Random();
                int rno = random.Next(0, 1000);
                photo.SaveAs(path1 + rno + lastPart);
            }
