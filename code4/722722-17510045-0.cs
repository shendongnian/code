    using System.Diagnostics;
    using System.Threading.Tasks;
    
    using Machine.Specifications;
    
    using Moq;
    
    using YourApp;
    
    using It = Machine.Specifications.It;
    
    namespace YourApp
    {
      class Foo
      {
      }
    
      public interface IWebClientWrapper
      {
        Task<string> DownloadStringAsync(string url);
      }
    
      public class JsonWebServiceClassProvider
      {
        readonly IWebClientWrapper _webClientWrapper;
    
        public JsonWebServiceClassProvider(IWebClientWrapper webClientWrapper)
        {
          _webClientWrapper = webClientWrapper;
        }
    
        public async Task<T> GetData<T>(string url) where T : class, new()
        {
          string jsonData = await _webClientWrapper.DownloadStringAsync(url);
          Debug.Assert(jsonData != null);
          return new T();
        }
      }
    }
    
    namespace Specs
    {
      public class When_calling_GetData_with_a_valid_Json_Service_Url
      {
        const string ValidJson = "{'Nome':'Rogerio','Idade':'51'}";
        static JsonWebServiceClassProvider JsonWebServiceClassProvider;
        static Mock<IWebClientWrapper> Wrapper;
        static AwaitResult<Foo> Result;
    
        Establish context = () =>
        {
          Wrapper = new Mock<IWebClientWrapper>();
          Wrapper.Setup(w => w.DownloadStringAsync(Moq.It.IsAny<string>()))
                 .Returns(Task.FromResult(ValidJson));
    
          JsonWebServiceClassProvider = new JsonWebServiceClassProvider(Wrapper.Object);
        };
    
        Because of = () => Result = JsonWebServiceClassProvider.GetData<Foo>("ignored").Await();
    
        It should_return_a_class_of_same_type = () => Result.AsTask.Result.ShouldBeOfType<Foo>();
      }
    }
