    public class MyModel: MvxViewModel
    {
      private readonly IMyService _myService;
      private bool _isBusy;
      public bool IsBusy
      {
        get { return _isBusy; }
        set { _isBusy = value; RaisePropertyChanged(() => IsBusy); ; }
      }
      public ICommand MyCommand
      {
        get
        {
          return new MvxCommand(async () => await DoMyCommand());
        }
      }
      public MyModel(IMyService myService)
      {
        _myService = myService;
      }
      public async Task DoMyCommand()
      {
        IsBusy = true;
        await Task.Run(() =>
        {
          _myService.LongRunningProcess();
        });
        IsBusy = false;
      }
    }
