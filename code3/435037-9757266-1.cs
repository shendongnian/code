    [HttpPost]
    public ActionResult Create(EmployeeViewModel viewModel)
    {
           if (Request.Files.Count > 0)
            {
                foreach (string file in Request.Files)
                {
                    string pathFile = string.Empty;
                    if (file != null)
                    {
                        string path = string.Empty;
                        string fileName = string.Empty;
                        string fullPath = string.Empty;
                        path = AppDomain.CurrentDomain.BaseDirectory + "directory where you want to upload file";//here give the directory where you want to save your file
                        if (!System.IO.Directory.Exists(path))//if path do not exit
                        {
                            System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "directory_name/");//if given directory dont exist, it creates with give directory name
                        }
                        fileName = Request.Files[file].FileName;
    
                        fullPath = Path.Combine(path, fileName);
                        if (!System.IO.File.Exists(fullPath))
                        {
    
                            if (fileName != null && fileName.Trim().Length > 0)
                            {
                                Request.Files[file].SaveAs(fullPath);
                            }
                        }
                    }
                }
            }
    }
