            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            if (UseProxy)
            {
                request.Proxy = new WebProxy(ProxyServer + ":" + ProxyPort.ToString());
                if (ProxyUsername.Length>0) 
                    request.Proxy.Credentials = new NetworkCredential(ProxyUsername, ProxyPassword);
            }
            //HttpWebRequest hrequest = (HttpWebRequest)request;
            //hrequest.AddRange(BytesRead); ::TODO: Work on this
            if (BytesRead>0) request.AddRange(BytesRead);
            WebResponse response = request.GetResponse();
            //result.MimeType = res.ContentType;
            //result.LastModified = response.LastModified;
            if (!resuming)//(Size == 0)
            {
                //resuming = false;
                Size = (int)response.ContentLength;
                SizeInKB = (int)Size / 1024;
            }
            acceptRanges = String.Compare(response.Headers["Accept-Ranges"], "bytes", true) == 0;
            //create network stream
            ns = response.GetResponseStream();
