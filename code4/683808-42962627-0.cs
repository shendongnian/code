            HttpClient client = new HttpClient();
            // set the base host address for the Api (comes from Web.Config)
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("ApiBase"));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add( 
              new MediaTypeWithQualityHeaderValue("application/json"));
            // Construct the HEAD only needed request. Note that I am requesting
            //  only the 1st page and 1st record from my API's endpoint.
            HttpRequestMessage request = new HttpRequestMessage(
              HttpMethod.Head, 
              "api/atms?page=1&pagesize=1");
            HttpResponseMessage response = await client.SendAsync(request);
            
            // FindAndParsePagingInfo is a simple helper I wrote that parses the 
            // json in the Header and populates a PagingInfo poco that contains 
            // paging info like CurrentPage, TotalPages, and TotalCount, which 
            // is the total number of records in the ATMs table.
            var pagingInfoForAtms = HeaderParser.FindAndParsePagingInfo(response.Headers);
            if (response.IsSuccessStatusCode)
                // This for testing only. pagingInfoForAtms.TotalCount correctly
                //  contained the record count
                return Content($"# of ATMs {pagingInfoForAtms.TotalCount}");
                // if request failed, execution will come through to this line 
                // and display the response status code and message. This is how
                //  I found out that I had to specify the HttpHead attribute.
                return Content($"{response.StatusCode} : {response.Headers.ToString()}");
            }
