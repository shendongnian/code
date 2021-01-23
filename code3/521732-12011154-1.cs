    string URL = 'https://www.example.com/authenticate.php";
    string myParameters = "username=user&password=pass";
    using (var webClient = new System.Net.WebClient()) {
            webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string HtmlResult = wc.UploadString(URI, myParameters);
            // Now parse with JSON.Net
    }
