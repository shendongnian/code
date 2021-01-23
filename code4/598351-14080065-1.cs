    [Route("/reqstars/search", "GET")]
    [Route("/reqstars/aged/{Age}")]
    public class SearchReqstars : IReturn<ReqstarsResponse>
    {
        public int? Age { get; set; }
    }
    var relativeUrl = new SearchReqstars { Age = 20 }.ToUrl("GET");
    var absoluteUrl = EndpointHost.Config.WebHostUrl.CombineWith(relativeUrl);
    relativeUrl.Print(); //=  /reqstars/aged/20
    absoluteUrl.Print(); //=  http://www.myhost.com/reqstars/aged/20
