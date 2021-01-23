        public Address verifyAddress(Address address)
        {
            this.client = new HttpClient();
            client.BaseAddress = new Uri("http://somesite.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var urlParm = URL + "verifyAddress";
            response = client.PostAsJsonAsync(urlParm,address).Result;
            var dataObjects = response.IsSuccessStatusCode ? response.Content.ReadAsAsync<Address>().Result : null;
            return dataObjects;
        }
