       [HttpPost]
        public ActionResult Add(HttpPostedFileBase uploadFile, int UserID)
        {
            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
           
                //instance the user.. i.e "User1"
                byte[] tempFile = new byte[uploadFile.ContentLength];
                uploadFile.InputStream.Read(tempFile, 0, uploadFile.ContentLength);
                
                User1.file.Content = tempFile;
                User1.file.SaveFile();
            }
            return RedirectToAction("Index");
        }
