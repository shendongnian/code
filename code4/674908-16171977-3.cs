    // Here when the response is being written out the data is pulled from the file to the destination(network) stream
    response.Content = new StreamContent(File.OpenRead(filePath));
    // Here we create a push stream content so that we can use XDocument.Save to push data to the destination(network) stream
    XDocument xDoc = XDocument.Load("Sample.xml", LoadOptions.None);
    PushStreamContent xDocContent = new PushStreamContent(
    (stream, content, context) =>
    {
         // After save we close the stream to signal that we are done writing.
         xDoc.Save(stream);
         stream.Close();
    },
    "application/xml");
