    public void Test() 
    { 
       Observable.Using(() => new Client(), 
    		(c) => ObservableGetParameters(c))
                        .Subscribe((response) => Debug.Print("response"), 
    		           (ex) => Debug.Print("{0} error: {1}", "name", ex.Message), 
    		           () => Debug.Print("{0} complete", "name"));
    }
    private static IObservable<Dictionary<string, Dictionary<string, string>>> ObservableGetParameters(Client client) 
    {
      return Observable.FromAsyncPattern<Dictionary<string, Dictionary<string, string>>>(client.BeginGetParameters, client.EndGetParameters)(); 
      }
    public class Client : IDisposable {
     public IAsyncResult BeginGetParameters(AsyncCallback cb, object o) { 
       return default(IAsyncResult);
    }
    public Dictionary<string, Dictionary<string, string>> EndGetParameters(IAsyncResult res) {
      return default(Dictionary<string, Dictionary<string, string>>);
    }
    public void Dispose() {}
    }
