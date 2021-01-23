    public class PageViewModel : IHandle<SomeMessage>
    {
       ...
    
       public async void Handle(SomeMessage message)
       {
          ShowLoadingAnimation();
    
          // makes UI very laggy, but still not dead
          await this.contentLoader.LoadContentAsync(); 
    
          HideLoadingAnimation();   
       }
    }
    
    public class ContentLoader 
    {
        public async Task LoadContentAsync()
        {
            var tasks = new List<Task>();
            tasks.Add(DoCpuBoundWorkAsync());
            tasks.Add(DoIoBoundWorkAsync());
            tasks.Add(DoCpuBoundWorkAsync());
            tasks.Add(DoSomeOtherWorkAsync());
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
