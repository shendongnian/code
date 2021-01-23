    using (var client = new HttpClient())
    {
        var response = client.GetAsync("http://google.com");
        if (response.Result.IsSuccessStatusCode)
        {
            // by calling .Result you are performing a synchronous call
            var responseContent = response.Result.Content; 
            // by calling .Result you are synchronously reading the result
            string responseString = responseContent.ReadAsStringAsync().Result;
            Console.WriteLine(responseString);
        }
    }
