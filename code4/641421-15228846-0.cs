    public static void LogApiCall(HttpRequest httpRequest, string resultText = "Success", int resultCode = 0)
    {
    
        XDocument bodyRequest = XDocument.Parse(GetDocumentContents(httpRequest));
        string methodName = bodyRequest.Root
                                        .Elements()
                                        .Where(e => e.Name.LocalName == "Body")
                                        .Elements()
                                        .FirstOrDefault().Name.LocalName;
    }
    
    private static string GetDocumentContents(HttpRequest request)
    {
        string documentContents;
        using (Stream receiveStream = request.InputStream)
        {
            using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
            {
                documentContents = readStream.ReadToEnd();
            }
        }
        return documentContents;
    }
