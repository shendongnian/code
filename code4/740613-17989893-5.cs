    HttpResponseMessage response = await client.PostAsync(
    "http://www.someAPI.com/api.xml", requestContent);
    response.EnsureSuccessStatusCode();
    dynamic content = response.Content.ReadAsAsync<ExpandoObject>().Result; // Notice the use of the dynamic keyword
    var myPropertyValue = content.MyProperty; // Compiles just fine, retrieves the value of this at runtime (as long as it exists, of course)
