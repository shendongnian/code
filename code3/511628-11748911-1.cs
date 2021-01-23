    public ActionResult GetFile()
    {    
       byte[] bytes = GetYourByteArrayForPDF();
       return File(bytes, "application/pdf","somefriendlyname.pdf");    
    }
