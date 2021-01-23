    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TestService : ITestService
    {
        public Stream GetMatAnalysis(Stream image)
        {
            MatAnalysisResult matAnalysis = new MatAnalysisResult { results = 10 };
            string result = JsonConvert.SerializeObject(matAnalysis);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }
    }
