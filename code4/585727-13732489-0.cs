     [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult UploadCSV(HttpPostedFileBase uploadFile)
            {
                var filePath = string.Empty;
                if (uploadFile.ContentLength <= 0)
                {
                    return View();
                }
                    filePath  = Path.Combine(Server.MapPath(this.UploadPath), "DeptartmentName",Path.GetFileName(uploadFile.FileName));
                if (new FileInfo(filePath).Exists)
                {
                    ViewBag.ErrorMessage =
                        "The file currently exists on the server.  Please rename the file you are trying to upload, delete the file from the server," +
                        "or contact IT if you are unsure of what to do.";
                    return View();
                }
                else
                {
                    uploadFile.SaveAs(filePath);
                    return RedirectToAction("UploadSuccess", new {fileName = uploadFile.FileName, processType = "sonar"});
                }
            }
    
     [HttpGet]
            public ActionResult UploadSuccess(string fileName, string processType)
            {
                ViewBag.FileName = fileName;
                ViewBag.PType = processType;
                return View();
            }
