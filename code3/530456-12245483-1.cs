        public ActionResult Upload()
        {
            TempData["Status"] = "";
            return View(new UploadViewModel());
        }
        [HttpPost]
        public ActionResult Upload(UploadViewModel upload) //string token, string filename, string moddate, object file
        {
            //*** Do something with the upload viewmodel
            // It's probably a good idea to store the message into tempdata
            TempData["Status"] = "Complete";
            return View();
        }
