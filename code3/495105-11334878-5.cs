    public ActionResult Load(spinnerValidation theData, HttpPostedFileBase file)
    
        if (file.ContentLength > 0)
        {
            var fileName = System.IO.Path.GetFileName(file.FileName);
            var fileUpload = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            file.SaveAs(fileUpload);
            if (System.IO.File.Exists(fileUpload)) 
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(fileUpload))
                {
                    var input = sr.ReadToEnd();
                    var lines = Regex.Split(input, "#!#");
                }
            }
        }
    }
