    [HttpPost]
    [ValidateInput(false)]
    public ActionResult StreamDebug2(string someParameter)
    {
      string postbody = "";
      Request.InputStream.Position = 0;
      using (StreamReader reader = new StreamReader(Request.InputStream, Encoding.UTF8))
      {
        postbody = reader.ReadToEnd();
      }
      return this.Content(postbody);
    }
