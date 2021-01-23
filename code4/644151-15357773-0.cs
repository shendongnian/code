     public class ProductsController : ApiController
    {      
        public HttpResponseMessage GetProductsByCategory(string url)
        {          
            HttpResponseMessage theResponse = null;
            // init a wep api Client
			var myClient = new HttpClient();
			var theTask = myClient.GetAsync(url).ContinueWith((lamdaObj) =>
			{
				theResponse = lamdaObj.Result;
			});
			// wait for task to complete. Not really async, is it?!
			theTask.Wait();
			// remove annoying header 
			theResponse.Content.Headers.Remove("Content-Disposition");
			return theResponse;
        }
    }
}
