var authenticationBytes = Encoding.ASCII.GetBytes("<username>:<password>");
using (HttpClient confClient = new HttpClient())
{
  confClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
         Convert.ToBase64String(authenticationBytes));
  confClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaType));  
  HttpResponseMessage message = confClient.GetAsync("<service URI>").Result;
  if (message.IsSuccessStatusCode)
  {
    var inter = message.Content.ReadAsStringAsync();
    List<string> result = JsonConvert.DeserializeObject<List<string>>(inter.Result);
  }
}
