    using(HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url))
    {
        using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using(Stream responseStream = response.GetResponseStream())
            {
                using(Stream outputStream = new FileStream(...))
                {
                    responseStream.CopyTo(outputStream);
                }
            }
        }
    }
