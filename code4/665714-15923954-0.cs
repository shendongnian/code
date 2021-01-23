    using System.Net;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    private async Task<DateTime?> GetNistTime()
    {
        DateTime? dateTime = null; 
        HttpClient httpClient = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("http://nist.time.gov/timezone.cgi?UTC/s/0"));
        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        string text = await httpResponseMessage.Content.ReadAsStringAsync();
        if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
        {
            string html = await httpResponseMessage.Content.ReadAsStringAsync();
            string time = Regex.Match(html, @">\d+:\d+:\d+<").Value; //HH:mm:ss format
            string date = Regex.Match(html, @">\w+,\s\w+\s\d+,\s\d+<").Value; //dddd, MMMM dd, yyyy
            dateTime = DateTime.Parse((date + " " + time).Replace(">", "").Replace("<", ""));
        }
        return dateTime;
    }
