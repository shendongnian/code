    [ActivityDescription("1.0")]
    public class DownloadActivity : Activity
    {
      //It supports both sync/async method.
      [ActivityMethod]
      public async Task<Response> Execute(string input)
      {
          //simulate downloading of file
          await Task.Delay(10);
          return new Response() { DownloadedFile = "downloaded path", PollingQueue = PollingQueue.Download};
      }
      
      public class Response
      {
          public string DownloadedFile;
      }
    }
