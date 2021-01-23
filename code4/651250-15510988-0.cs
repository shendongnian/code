                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://mydomain.cc/saveimage.php");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                string postData = String.Format("image=", myBase64EncodedImage);   
                // Getting the request stream.
                request.BeginGetRequestStream
                    (result =>
                    {
                        // Sending the request.
                        using (var requestStream = request.EndGetRequestStream(result))
                        {
                            using (StreamWriter writer = new StreamWriter(requestStream))
                            {
                                writer.Write(postData);
                                writer.Flush();
                            }
                        }
                        // Getting the response.
                        request.BeginGetResponse(responseResult =>
                        {
                            var webResponse = request.EndGetResponse(responseResult);
                            using (var responseStream = webResponse.GetResponseStream())
                            {
                                using (var streamReader = new StreamReader(responseStream))
                                {
                                    string srresult = streamReader.ReadToEnd();
                                }
                            }
                        }, null);
                    }, null);
            }
