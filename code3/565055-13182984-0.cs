    [HttpPost]
        public ActionResult PostPhotoOnWall(HttpPostedFileBase file)
        {
            var filename = Path.GetFileName(file.FileName);
            var client = new FacebookClient();
           
            // Post to user's wall
            var postparameters = new Dictionary<string, object>();
            var media = new FacebookMediaObject
            {
                FileName = filename,
                ContentType = "image/jpeg"
            };
            var path = Path.Combine(Server.MapPath("~/Content/themes/base/images"),filename);
            file.SaveAs(path);
            byte[] img = System.IO.File.ReadAllBytes(path);
            media.SetValue(img);
          postparameters["source"] = media;
            postparameters["access_token"] = Session["access_token"].ToString();
         //   postparameters["picture"] = "http://localhost:8691/Content/themes/base/images/12WIPJ50240-2V91.jpg";
            var result = client.Post("/me/photos", postparameters);
            return View("PostPhoto");
        }
