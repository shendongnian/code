        using System;
        using System.Net.Http;
       
        private async void getSite(string url)
        {
            HttpClient hc = new HttpClient();
            HttpResponseMessage response = await hc.GetAsync(new Uri(url, UriKind.Absolute));
            string source = await response.Content.ReadAsStringAsync();
           
            //process the source here
           
        }
