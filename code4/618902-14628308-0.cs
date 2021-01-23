    request.Headers.Authorization = 
        new AuthenticationHeaderValue(
            "Basic", 
            Convert.ToBase64String(
                System.Text.ASCIIEncoding.ASCII.GetBytes(
                    string.Format("{0}:{1}", "yourusername", "yourpwd"))));
