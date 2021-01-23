      public class BrowserViewModel : ViewModelBase
        {
            public BrowserViewModel() {
                
            }
    
            public void AddUrl(string url)
            {
                (App.Current as App).Urls.Add(url);
            }
        }
