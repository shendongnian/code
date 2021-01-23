    public ActionResult DownloadFile(int fileID, int propertyId)
    {
        var item = _tasks.GetByKey(fileID);
        if (item.PropertyEntity.PropertyID == propertyId)
        {
            string docType = item.FileName.Substring(item.FileName.IndexOf(".") + 1);
            switch (docType.ToLower())
            {
                case "doc":
                    docType = "application/msword";
                    break;
                case "jpg":
                    docType = "image/jpeg";
                    break;
                default:
                    // i.e. do nothing else - this may change
                    docType = "application/" + docType;
                    break;
            }
                
            string doc = item.DocumentLocation.Replace("..", "~");
            return File(doc, docType);
        }
        else
        {
            return View("NotFound");
        }
    }
