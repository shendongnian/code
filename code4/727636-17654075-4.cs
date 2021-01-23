            var  _client = new HttpClient();
            _client.BaseAddress = new Uri("http://httpbin.org/");
            var response = await _client.DeleteAsync("/delete");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
