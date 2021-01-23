    public void ProcessRequest(HttpContext context)
            {           
                var response = Gets3Response(context.Request.QueryString["file"]);
                if (response != null)
                {
                    using (response)
                    {
                        var mimEtype = response.ContentType;
                        context.Response.ContentType = mimEtype;
                        using (var responseStream = response.ResponseStream)
                        {
                            var buffer = new byte[8000];
                            var bytesRead = -1;
                            while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                context.Response.OutputStream.Write(buffer, 0, bytesRead);
                            }
                        }
                        context.Response.Flush();
                        context.Response.End();
                    }
                }
                else
                {
    
                    context.Response.Write("Unable to retrieve content!");
    
                }
            }
    
    
    
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
        private static GetObjectResponse Gets3Response(string fileName)
            {
                GetObjectResponse response;
                if (fileName.Trim().Length == 0)
                {
                    return null;
                }
                try
                {
                    var request = new GetObjectRequest();
                    request.WithBucketName(BucketName).WithKey(fileName);
                    response = AmazonS3ClientProvider.CreateS3Client().GetObject(request);
                }
                catch (AmazonS3Exception amazonS3Exception)
                {
                    if (amazonS3Exception.ErrorCode != null &&      (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                    {
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
    
                return response;
            }
