    public bool IsReusable
    {
        get { return false; }
    }
    
    public void ProcessRequest(HttpContext context)
    {
        // find out what we're trying to do first
        string method = context.Request.HttpMethod;
        switch (method)
        {
            case "GET":
                // read the query string for the document name or ID
                // read the file in from the shared folder
                // write those bytes to the response, ensuring to set the Reponse.ContentType
                // and also remember to issue Reponse.Clear()
                break;
            case "PUT":
                // read the Headers from the Request to get the byte[] of the file to CREATE
                // write those bytes to disk
                // construct a 200 response
                break;
            case "POST":
                // read the Headers from the Request to get the byte[] of the file to UPDATE
                // write those bytes to disk
                // construct a 200 response
                break;
            case "DELETE":
                // read the Headers from the Request to get the byte[] of the file to DELETE
                // write those bytes to disk
                // construct a 200 response
                break;
        }
    }
