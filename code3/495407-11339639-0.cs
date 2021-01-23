        HttpWebResponse response;
        if (VerbMethod("POST", "TheMethod", "http://theurl.com", "parameter1=a", theGuid, out response))
        {
            using (response)
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    string responseString = sr.ReadToEnd();
                }
            }
        }
