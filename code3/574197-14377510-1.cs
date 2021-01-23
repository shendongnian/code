            System.Net.ServicePointManager.Expect100Continue = false;
            var request = WebRequest.Create("https://api.soundcloud.com/tracks") as HttpWebRequest;
            //some default headers
            request.Accept = "*/*";
            request.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8,ru;q=0.6");
            //file array
            var files = new UploadFile[] { new UploadFile(Server.MapPath("Downloads//0.mp3"), "track[asset_data]", "application/octet-stream") };
            //other form data
            var form = new NameValueCollection();
            form.Add("track[title]", "Some title");
            form.Add("track[sharing]", "public");
            form.Add("oauth_token", "");
            form.Add("format", "json");
            form.Add("Filename", "0.mp3");
            form.Add("Upload", "Submit Query");
            try
            {
                using (var response = HttpUploadHelper.Upload(request, files, form))
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        Response.Write(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
