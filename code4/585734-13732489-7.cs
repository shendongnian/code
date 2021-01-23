      public ActionResult Index(string fileName, string type)
            {
                ViewBag.File = fileName;
                ViewBag.PType = type;
                switch (type)
                {
                    case "somematch":
                        if (!_fileProcessors.ContainsKey(fileName)) _fileProcessors.Add(fileName, new SonarCsvProcessor(Path.Combine(Server.MapPath(this.UploadPath), "DepartmentName", fileName), true));
                        break;
                    default:
                        break;
                }
                return PartialView();
            }
