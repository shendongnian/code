    public void ProcessRequest(HttpContext context)
    {
    string jsonString = "";
    string rawJson = "";
    System.Diagnostics.Debugger.Break();
    
    HttpContext.Current.Request.InputStream.Position = 0;
    string responseString;
    var jsonSerializer = new JavaScriptSerializer();
    /*Set the stream position to 0 */
    context.Request.InputStream.Position = 0;
    
    using (System.IO.StreamReader inputStream = new StreamReader(context.Request.InputStream))
    {
    rawJson = inputStream.ReadToEnd();
    }
    var objNewPerson = jsonSerializer.Deserialize<NewPerson>(rawJson);
    if (clientList != null)
    {
    
    responseString = objNewPerson.FirstName + " " + objNewPerson.LastName ;
    }
    else
    resp="No Record Found";
    } // eof ProcessRequest
