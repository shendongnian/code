    public sealed class MyViewModel : INotifyPropertyChanged
    {
      private readonly DataService _service;
      private MyViewModel(DataService service)
      {
        _service = service;
      }
      private async Task InitializeAsync()
      {
        var result = await _service.GetData(); // async initialization
        Data = result; // update data-bound properties with the results
      }
      // Data triggers INotifyPropertyChanged on write
      public string Data { get { ... } set { ... } }
      public static async Task<MyViewModel> CreateAsync()
      {
        var ret = new MyViewModel();
        await ret.InitializeAsync();
        return ret;
      }
    }
