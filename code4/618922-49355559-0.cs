       using (var client = new HttpClient())
            {
                var webUrl ="http://localhost/saleapi/api/";
                var uri = "api/sales";
                client.BaseAddress = new Uri(webUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = true;
                //Set Basic Auth
                var user = "username";
                var password = "password";
                var base64String =Convert.ToBase64String( Encoding.ASCII.GetBytes($"{user}:{password}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",base64String);
                var result = await client.PostAsJsonAsync(uri, model);
                return result;
            }
