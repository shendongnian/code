    public void GetObject(string AccessKeyID, string SecretKey){           
			/*objectKey = folder/folder/filename.zzz*/
            var url = "http://somehost/bucket/objectkey"
			
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
			/*Fiddler proxy*/
			/*request.Proxy = new WebProxy("http://127.0.0.1:8888");*/
            request.Headers.Add("X-Amz-Date",DateTime.Now.ToString());
            request.Headers.Add("Authorization", $"AWS {AccessKeyID}:{SignAuthorizationString(request, SecretKey)}");
            WebResponse response = request.GetResponse();
			}
    private string SignAuthorizationString(HttpWebRequest request, string SecretKey){
            //TODO: DOCS - http://docs.aws.amazon.com/AmazonS3/latest/dev/RESTAuthentication.html
            
            string canonicalizedResource = "/" + BucketName + request.RequestUri.PathAndQuery;
            string canonicalizedAmzHeaders  = ComposeSignatureAmzHeadersForSigning(request);
            string stringToSign = request.Method + "\n"
                                  + request.Headers.Get("Content-MD5") + "\n"
                                  + request.ContentType + "\n"
                                  + request.Headers.Get("Date") + "\n" /*Here the date will be blank*/
                                  + canonicalizedAmzHeaders + canonicalizedResource;
            return GetSignedMessage(SecretKey, stringToSign);
			}
     private string ComposeSignatureAmzHeadersForSigning(HttpWebRequest request){
            SortedDictionary<string, string> headersDictionary = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (string key in request.Headers.Keys)
            {
                if (key.StartsWith("x-amz"))
                {
                    if ("x-amz-meta-reviewedby".Equals(key))
                    {
                        if (headersDictionary.ContainsKey(key))
                            headersDictionary[key] = headersDictionary[key] + "," + request.Headers[key];
                        else
                            headersDictionary[key] = request.Headers[key];
                    }
                    else
                        headersDictionary[key] = request.Headers.Get(key);
                }
            }
            StringBuilder stringBuilder = new StringBuilder("\n");
            foreach (var pair in headersDictionary)
            {
                stringBuilder.Append(pair.Key)
                    .Append(":")
                    .Append(pair.Value)
                    .Append("\n");
            }
            return stringBuilder.Length > 1 ? stringBuilder.ToString() : "";
			}
    private static string GetSignedMessage(string key, string message){
            var crypt = HMACSHA1.Create();
            crypt.Key = Encoding.ASCII.GetBytes(key);
            crypt.ComputeHash(Encoding.UTF8.GetBytes(message));
            return Convert.ToBase64String(crypt.Hash);
			}
