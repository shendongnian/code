    [ImplementPropertyChanged]
    public class MyModel: MvxViewModel
    {
        private readonly IMyService _myService;
    
        public bool IsBusy { get; set; }
    
        public MyModel(IMyService myService)
        {
            _myService = myService;
        }
    
        public async Task DoSomething()
        {
            IsBusy = true;
            await Task.Factory.StartNew(() =>
            {
                    _myService.LongRunningProcess();
            });
            IsBusy = false;
        }
    }
