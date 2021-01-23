    public class TwitterController : ApiController
    {
         DataScrapperApi api = new DataScrapperApi();
         TwitterAndKloutData data = api.GetTwitterAndKloutData(screenName);
         return data;
    }
    public class TwitterAndKloutData
    {
       // implement properties here
    }
