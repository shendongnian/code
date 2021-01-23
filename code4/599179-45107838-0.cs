    public IHttpActionResult DownloadFile(string fileName)
    {
       if (!File.Exists(fileName))
       {
          return NotFound();
       }
    
       // Do something
       return Ok(yourFile);
    }
