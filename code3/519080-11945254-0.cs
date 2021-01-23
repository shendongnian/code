    using (MyClient client = new MyClient())
        {
            client.HeadOnly = true;
            string uri = "http://www.google.com";
            byte[] body = client.DownloadData(uri); // note should be 0-length
            string type = client.ResponseHeaders["content-type"];
            client.HeadOnly = false;
            // check 'tis not binary... we'll use text/, but could
            // check for text/html
            if (type.StartsWith(@"text/"))
            {
                string text = client.DownloadString(uri);
                Console.WriteLine(text);
            }
        }
