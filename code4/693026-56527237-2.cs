    [HttpGet]
    public virtual ActionResult Download(string fileGuid, string fileName)
    {   
        if (_cache.Get<byte[]>(fileGuid) != null)
        {
            byte[] data = _cache.Get<byte[]>(fileGuid);
            _cache.Remove(fileGuid); //cleanup here as we don't need it in cache anymore
            return File(data, "application/vnd.ms-excel", fileName);
        }
        else
        {
            // Something has gone wrong...
            return View("Error"); // or whatever/wherever you want to return the user
        }
    }
