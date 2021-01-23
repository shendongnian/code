            string apiKey = "Your api key";
            string cx = "Your custom search engine id";
            string query = "Your query";
            var svc = new Google.Apis.Customsearch.v1.CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
            var listRequest = svc.Cse.List(query);
            
            listRequest.Cx = cx;
            var search = listRequest.Fetch();
            foreach (var result in search.Items)
            {
                Response.Output.WriteLine("Title: {0}", result.Title);
                Response.Output.WriteLine("Link: {0}", result.Link);
            }
