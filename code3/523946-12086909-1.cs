    var httpClient = new HttpClient();
	httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	Request request = new Request();
	HttpResponseMessage response = httpClient.PostAsJsonAsync("http://localhost/Pusher/PushMessage?x=foo&y=bar", request).Result;
	//check if (response.IsSuccessStatusCode)
	var createResult = response.Content.ReadAsAsync<YourResultObject>().Result;
