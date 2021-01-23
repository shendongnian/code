        HttpWebRequest wrq = (HttpWebRequest)WebRequest.Create(@"http://webstrand.comoj.com/locked/safe.php");
        HttpWebResponse wrs = null;
        try
        {
            wrs = (HttpWebResponse)wrq.GetResponse();
        }
        catch (System.Net.WebException protocolError)
        {
            if (((HttpWebResponse)protocolError.Response).StatusCode == HttpStatusCode.Unauthorized)
            {
                //do something
            }
        }
        catch (System.Exception generalError)
        {
            //run to the hills
        }
        if (wrs.StatusCode == HttpStatusCode.OK)
        {
            Uri uri = wrs.ResponseUri;
            StreamReader strdr = new StreamReader(wrs.GetResponseStream());
            string html = strdr.ReadToEnd();
            wrs.Close();
            strdr.Close();
        }
