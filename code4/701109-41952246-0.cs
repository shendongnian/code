       public string CommonFileSave(HttpPostedFileBase postedFile, string filePath)       
       {
            string resultResponse = "sccuess";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
                postedFile.SaveAs(filePath + postedFile.FileName);
            }
            else
            {
                filePath = filePath + postedFile.FileName;
                if (!System.IO.File.Exists(filePath))
                {
                    postedFile.SaveAs(filePath);
                }
            }
            return resultResponse;
        }
