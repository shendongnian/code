    string uri = RSConnection.StorageUrl + "/" + container + "/" + file.SelectSingleNode("name").InnerText;
    var req = (HttpWebRequest)WebRequest.Create(uri);
    req.Headers.Add("X-Auth-Token", RSConnection.AuthToken);
    req.Method = "GET";
    using (var resp = req.GetResponse() as HttpWebResponse)
    {
        using (Stream stream = resp.GetResponseStream())
        {
            //I haven't tested this path
            Amazon.S3.Transfer.TransferUtility trans = new Amazon.S3.Transfer.TransferUtility(S3Client);
            trans.Upload(new HttpResponseStream(stream, length), config.Element("root").Element("S3BackupBucket").Value, container + file.SelectSingleNode("name").InnerText);
            //Use EITHER the above OR the below
            //I have tested this with dropbox data
            PutObjectRequest putReq = new PutObjectRequest();
            putReq.WithBucketName(config.Element("root").Element("S3BackupBucket").Value);
            putReq.WithKey(container + file.SelectSingleNode("name").InnerText);
            putReq.WithInputStream(new HttpResponseStream(stream, length)));
            using (S3Response putResp = S3Client.PutObject(putReq))
            {
            }
        }
    }
