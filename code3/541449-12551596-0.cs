    public Stream DownloadFileThroughWebClient(string strFilePath)
    {
        int count = 0; 
        int count404 = 0;
        while (count < 120 && count404 < 30)
        {
            try
            {
                byte[] v;
                using (var wc = new WebClient())
                {
                    v = wc.DownloadData(strFilePath);
                }
                
                if (v.Length > 0)
                {
                    return new MemoryStream(v);
                }
                count++;
                count404 = 0;
            }
            catch (WebException ex)
            {
                count++;
                var httpWebResponse = ex.Response as HttpWebResponse;
                if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    count404++;
                    // you may wanna break out of the loop here since there's no point in continuing 
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        return null;
    }
