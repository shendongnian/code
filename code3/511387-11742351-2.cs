        string webUrl = "http://www.google.com";
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(webUrl);
        req.Credentials = new NetworkCredential("UUU", "PPP");
        using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
        {
            using (Stream stream = resp.GetResponseStream())
            {
                int read;
                string line;
                byte[] data = new byte[4096];
                while ((read = stream.Read(data, 0, data.Length)) > 0)
                {
                    line = Encoding.GetEncoding("ASCII").GetString(data, 0, data.Length);
                    if (line.Contains("(function(){try{var a=window.gbar;"))
                    {
                        Console.WriteLine("End Bit founded..");
                        // Some more logic?
                        break;
                    }
                    data = new byte[4096];
                    Console.WriteLine(line);
                }
            }
        }
        Console.WriteLine("End of Stream");
