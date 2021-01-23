    private string GetEntity(String tableName, String partitionKey, String rowKey)
    {
        string result = "";
        String requestMethod = "GET";
        String urlPath = String.Format("{0}(PartitionKey='{1}',RowKey='{2}')",tableName, partitionKey, rowKey);
        DateTime now = DateTime.UtcNow;
        HttpWebResponse response;
        string uri = AzureStorageConstants.TableEndPoint + urlPath;
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
        request.Method = requestMethod;
        request.ContentLength = 0;
        request.Headers.Add("x-ms-date", now.ToString("R", System.Globalization.CultureInfo.InvariantCulture));
        request.Headers.Add("x-ms-version", "2009-09-19");
        request.ContentType = "application/atom+xml";
        request.Headers.Add("DataServiceVersion", "1.0;NetFx");
        request.Headers.Add("MaxDataServiceVersion", "1.0;NetFx");
        request.Headers.Add("If-Match", "*");
        request.Headers.Add("Accept-Charset", "UTF-8");
        request.Headers.Add("Authorization", AuthorizationHeader(requestMethod, now, request));
        request.Accept = "application/atom+xml";
        using (response = request.GetResponse() as HttpWebResponse)
        {
            Stream dataStream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(dataStream))
            {
                result = reader.ReadToEnd();
            }
        }
        return result;
    }
    public string AuthorizationHeader(string method, DateTime now, HttpWebRequest request)
    {
        string MessageSignature;
        MessageSignature = String.Format("{0}\n\n{1}\n{2}\n{3}",
            method,
            "application/atom+xml",
            now.ToString("R", System.Globalization.CultureInfo.InvariantCulture),
            GetCanonicalizedResource(request.RequestUri, AzureStorageConstants.Account)
            );
        byte[] SignatureBytes = System.Text.Encoding.UTF8.GetBytes(MessageSignature);
        System.Security.Cryptography.HMACSHA256 SHA256 = new System.Security.Cryptography.HMACSHA256(Convert.FromBase64String(AzureStorageConstants.Key));
        String AuthorizationHeader = "SharedKey " + AzureStorageConstants.Account + ":" + Convert.ToBase64String(SHA256.ComputeHash(SignatureBytes));
        return AuthorizationHeader;
    }
    public string GetCanonicalizedResource(Uri address, string accountName)
    {
        StringBuilder str = new StringBuilder();
        StringBuilder builder = new StringBuilder("/");
        builder.Append(accountName);
        builder.Append(address.AbsolutePath);
        str.Append(builder.ToString());
        NameValueCollection values2 = new NameValueCollection();
        NameValueCollection values = HttpUtility.ParseQueryString(address.Query);
        foreach (string str2 in values.Keys)
        {
            ArrayList list = new ArrayList(values.GetValues(str2));
            list.Sort();
            StringBuilder builder2 = new StringBuilder();
            foreach (object obj2 in list)
            {
                if (builder2.Length > 0)
                {
                    builder2.Append(",");
                }
                builder2.Append(obj2.ToString());
            }
            values2.Add((str2 == null) ? str2 : str2.ToLowerInvariant(), builder2.ToString());
        }
        ArrayList list2 = new ArrayList(values2.AllKeys);
        list2.Sort();
        foreach (string str3 in list2)
        {
            StringBuilder builder3 = new StringBuilder(string.Empty);
            builder3.Append(str3);
            builder3.Append(":");
            builder3.Append(values2[str3]);
            str.Append("\n");
            str.Append(builder3.ToString());
        }
        return str.ToString();
    }
