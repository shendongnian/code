           // You must change the URL to point to your Web server.
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            // allows for validation of SSL conversations
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            WebResponse respon = req.GetResponse();
            Stream res = respon.GetResponseStream();
            string ret = "";
            byte[] buffer = new byte[1048];
            int read = 0;
            while ((read = res.Read(buffer, 0, buffer.Length)) > 0)
            {
                Console.Write(Encoding.ASCII.GetString(buffer, 0, read));
                ret += Encoding.ASCII.GetString(buffer, 0, read);
            }
            return ret;
