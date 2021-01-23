    var request = WebRequest.Create(...);
    ...
    using (var response = request.GetResponse())
    using (var stream = response.GetStream())
    {
        var doc = XDocument.Load(stream);
        if (int.TryParse(doc.Root.Value, out value))
        {
            
            // the parsing was successful => you could do something with
            // the integer value you have just read from the body of the response
            // assuming the server returned the XML you have shown in your question,
            // value should equal 427 here.
        }
    }
