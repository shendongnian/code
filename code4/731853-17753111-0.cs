    [HttpPost]
    public ActionResult Upload()
    {
        try
        {
            if (Request.Files.Count > 0)
            {
                string tempFolder = "...";
                var file = Request.Files[0];
                if(UploadFile(tempFolder, file))
                {
                  // Return a View to show a message that file was successfully uploaded...
                  return View();
                }   
            }
        }
        catch (Exception e)
        {
            // Handle the exception here...
        }
    }
