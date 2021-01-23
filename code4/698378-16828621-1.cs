     public ActionResult Upload(FormCollection collection)
            {
                WebImage UploadImage = WebImage.GetImageFromRequest();
                long documentID;
                string finalImageName = null;
                if (!long.TryParse(collection.AllKeys[0], out documentID))
