		var handler = new HttpClientHandler {UseDefaultCredentials = true};
            using (var client = new HttpClient(handler))
            {   
                client.BaseAddress = new Uri("https://IE url.com");  
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
  		var  postDataObject = new
                    {
                        SCName = properties.Site.PortalName,
                        TotalSites = properties.Web.Webs.Count
 		 };
		var jsonPostData = new JavaScriptSerializer().Serialize(postDataObject);
                    HttpContent content = new StringContent(jsonPostData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("/controllerclassname/InsertUpdateDataOperation", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
			//Check the response here
                      //  var webApiResponse = response.Content.ReadAsStringAsync().Result;                    
                    }   
