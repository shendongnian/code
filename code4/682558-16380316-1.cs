    private void ReadCallback(IAsyncResult asynchronousResult)
    {
        HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
        HttpWebResponse response = (HttpWebResponse)
            request.EndGetResponse(asynchronousResult);
        using (IsolatedStorageFile isf =
            IsolatedStorageFile.GetUserStoreForSite())
        {
            using (IsolatedStorageFileStream isfs = isf.OpenFile("CookieExCookies",
                FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(isfs))
                {
                    foreach (Cookie cookieValue in response.Cookies)
                    {
                        sw.WriteLine("Cookie: " + cookieValue.ToString());
                    }
                    sw.Close();
                }
            }
    
        }
    }
