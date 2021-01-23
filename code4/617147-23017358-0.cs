    using Ionic.Zip; // from NUGET-Package "DotNetZip"
    public HttpResponseMessage Zipped()
    {
        using (var zipFile = new ZipFile())
        {
            // add all files you need from disk, database or memory
            // zipFile.AddEntry(...);
            return ZipContentResult(zipFile);
        }
    }
    protected HttpResponseMessage ZipContentResult(ZipFile zipFile)
    {
        // inspired from http://stackoverflow.com/a/16171977/92756
        var pushStreamContent = new PushStreamContent((stream, content, context) =>
        {
            zipFile.Save(stream);
            stream.Close(); // After save we close the stream to signal that we are done writing.
        }, "application/zip");
        return new HttpResponseMessage(HttpStatusCode.OK) {Content = pushStreamContent};
    }
