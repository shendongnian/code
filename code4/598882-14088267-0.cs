    public ActionResult GetFile(int id)
    {
      var fileInfo=repositary.GetFileDedetails(id);
      var byteArrayOFFile=fileInfo.FileContentAsByteArray();
      return File(byteArrayOFFile,"application/pdf","yourFriendlyName.pdf");
    }
