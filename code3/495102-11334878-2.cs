    public ActionResult Load(spinnerValidation theData, HttpPostedFileBase file)
    
        if (file.ContentLength > 0)
        {
            var filePath = Server.MapPath(file.FileName);
            using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
            {
                var input = sr.ReadToEnd();
                var lines = Regex.Split(input, "#!#");
            }
        }
    }
