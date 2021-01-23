    /// <summary>
    /// Uploads a blob in a blob container where SAS permission is defined on a blob container using REST API.
    /// </summary>
    /// <param name="blobContainerSasUri"></param>
    static void UploadBlobWithRestAPISasPermissionOnBlobContainer(string blobContainerSasUri)
    {
        string blobName = "sample.txt";
        string sampleContent = "This is sample text.";
        int contentLength = Encoding.UTF8.GetByteCount(sampleContent);
        string queryString = (new Uri(blobContainerSasUri)).Query;
        string blobContainerUri = blobContainerSasUri.Substring(0, blobContainerSasUri.Length - queryString.Length);
        string requestUri = string.Format(CultureInfo.InvariantCulture, "{0}/{1}{2}", blobContainerUri, blobName, queryString);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
        request.Method = "PUT";
        request.Headers.Add("x-ms-blob-type", "BlockBlob");
        request.ContentLength = contentLength;
        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(Encoding.UTF8.GetBytes(sampleContent), 0, contentLength);
        }
        using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
        {
             
        }
    }
