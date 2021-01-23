    public static string RedirectPath(string url)
    {
        StringBuilder sb = new StringBuilder();
        string location = string.Copy(url);
        while (!string.IsNullOrWhiteSpace(location))
        {
            sb.AppendLine(location); // you can also use 'Append'
            HttpWebRequest request = HttpWebRequest.CreateHttp(location);
            request.AllowAutoRedirect = false;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                location = response.GetResponseHeader("Location");
            }
        }
        return sb.ToString();
    }
