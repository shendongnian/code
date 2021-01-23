    HttpClient client = new HttpClient();
    string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
    client.BaseAddress = new Uri(baseApiAddress);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    HttpResponseMessage response=client.GetAsync("/api/GetData",data, new JsonMediaTypeFormatter()).Result;
    if (response.IsSuccessStatusCode)
    {
    var mydata = response.Content.ReadAsAsync<MyData>().Result;
    }
    else
    {
    Debug.WriteLine(response.ReasonPhrase);
    }
