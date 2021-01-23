                string URI = "http://www.indianrail.gov.in/cgi_bin/inet_pnrstat_cgi.cgi";
                string Parameters = Uri.EscapeUriString("lccp_pnrno1=8561180604&amp;submitpnr=Get Status");
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,URI);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                request.Headers.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8",0.7));
                request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-us",0.5));
                request.Content = new StreamContent(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(Parameters)));
                request.Content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                request.Headers.Host = "www.indianrail.gov.in";
                request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
                request.Headers.Referrer = new Uri("http://www.indianrail.gov.in/pnr_stat.html");
                var result = await client.SendAsync(request);
                var content = await result.Content.ReadAsStringAsync();  
  
