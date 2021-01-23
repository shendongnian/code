    public static MemoryStream  get_file_Istream(string file_id)
        {
            string data = "cmd=get_file&id=" + file_id + "&token=" + Token.curent_token;
            string Uri = URL.address;
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            request.Method = "POST";
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] EncodedPostParams = Encoding.UTF8.GetBytes(data);
            request.ContentLength = EncodedPostParams.Length;
            request.GetRequestStream().Write(EncodedPostParams, 0, EncodedPostParams.Length);
            request.GetRequestStream().Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            MemoryStream mm = new MemoryStream();
            response.GetResponseStream().CopyTo(mm);
            
            return mm;
            //ResponseStream = response.GetResponseStream();
        }
