        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase myFile)
        {
            myFile = Request.Files["file"];
            if (myFile != null && myFile.ContentLength > 0)
            {
                // your code ....
            }
            return View();
        }
