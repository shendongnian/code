    public static int Send(string uri)
        {
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(uri);
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                   if (response.StatusCode == HttpStatusCode.OK) return 0;
                }
            }
            catch (Exception e)
            {
                if (request != null) request.Abort();
            }
            return -1;
        }
